using DotNetCoolMovies.Data;
using DotNetCoolMovies.Data.Repository;
using DotNetCoolMovies.Data.Services;
using DotNetCoolMovies.Infrastructure;
using DotNetCoolMovies.Infrastructure.AutoMapper;
using DotNetCoolMovies.Infrastructure.Middleware;
using DotNetCoolMovies.Infrastructure.Validators;
using FluentValidation.AspNetCore;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Polly;
using Polly.Extensions.Http;
using System;
using System.Net.Http;

namespace DotNetCoolMovies.ApiService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        private readonly string _policyName = "CorsPolicy";

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            string serviceTitle = "DotNet Cool Movies";

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = serviceTitle, Version = "v1" });
            });

            services.AddDbContext<CoolMoviesAppContext>(options => options.UseSqlServer(Configuration.GetConnectionString("SQLConn")));

            services.AddAutoMapper(options => options.AddProfile(new AutomapperConfig()));

            services.AddMvc().AddFluentValidation(mvcConf => mvcConf.RegisterValidatorsFromAssemblyContaining<ModelValidators>());

            services.AddTransient<IEntityGenericRepository, EntityGenericRepository<CoolMoviesAppContext>>();

            services.AddTransient<IBusinessLogicService, RepositoryService<IEntityGenericRepository>>();

            services.AddCors(options =>
            {
                options.AddPolicy(_policyName, builder => builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });

            services.AddHttpClient(Constants.HttpClientFactoryName, client =>
            {
                client.DefaultRequestHeaders.Add("Accept", "application/json");
            })
                .SetHandlerLifetime(TimeSpan.FromMinutes(5))
                .AddPolicyHandler(GetRetryPolicy());

            //adding healthchecks components
            services.AddHealthChecks().AddSqlServer(
                connectionString: Configuration.GetConnectionString("SQLConn"),
                name: "SQL Server (Express)",
                failureStatus: HealthStatus.Unhealthy);

            //adding healthchecks UI
            services.AddHealthChecksUI(opt =>
            {
                opt.SetEvaluationTimeInSeconds(15); //time in seconds between check
                opt.MaximumHistoryEntriesPerEndpoint(60); //maximum history of checks
                opt.SetApiMaxActiveRequests(1); //api requests concurrency

                opt.AddHealthCheckEndpoint(serviceTitle, "/healthcheck"); //map health check api
            })
            .AddInMemoryStorage();
        }

        private static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
        {
            return HttpPolicyExtensions
                .HandleTransientHttpError()
                .OrResult(msg => msg.StatusCode != System.Net.HttpStatusCode.OK)
                .WaitAndRetryAsync(2, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DotNet Cool Movies v1"));
            }

            app.UseGlobalExceptionMiddleware();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(_policyName);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                //adding endpoint of health check for the health check ui in UI format
                endpoints.MapHealthChecks("/healthcheck", new HealthCheckOptions
                {
                    Predicate = _ => true,
                    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
                });

                //map healthcheck ui endpoing - default is /healthchecks-ui/
                endpoints.MapHealthChecksUI();

                endpoints.MapControllers();
            });
        }
    }
}