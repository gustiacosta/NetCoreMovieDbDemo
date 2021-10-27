using AutoMapper;
using DotNetCoolMovies.Core.Domain;
using DotNetCoolMovies.Core.Models;
using DotNetCoolMovies.Data.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace DotNetCoolMovies.ApiService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MoviesController : BaseController
    {
        private readonly ILogger<MoviesController> _logger;

        public MoviesController(ILogger<MoviesController> logger, IMapper mapper,
                                IHttpClientFactory clientFactory, IBusinessLogicService service)
        {
            _logger = logger;
            _mapper = mapper;
            _service = service;
            _httpClientFactory = clientFactory;
        }

        /// <summary>
        /// get list of all movies, ordered by title
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                _logger.LogInformation($"List of all movies requested");

                Stopwatch stopWatch = new();
                stopWatch.Start();

                // -----------------------------------------------------------------------------------------------------------
                // get movie list, including related entities (sub entities are added automatically upon dbcontext config.)
                // -----------------------------------------------------------------------------------------------------------
                var _movies = await _service.GetAsync<Movie>(null, o => o.OrderBy(c => c.Title), null, null, inc => inc.Actors, inc => inc.Genres);
                var movies = _mapper.Map<IEnumerable<MovieModel>>(_movies);

                stopWatch.Stop();

                if (movies == null)
                {
                    return Ok(new ResponseModel
                    {
                        Message = "No movies yet",
                        StatusCode = StatusCodes.Status200OK,
                        ElapsedTime = stopWatch.ElapsedMilliseconds,
                    });
                }

                // ---------------------------------------------------------------------------------
                // here we use a generic reponse model                
                // ---------------------------------------------------------------------------------
                return Ok(new ResponseModel
                {
                    Message = $"Here is the movie list",
                    StatusCode = StatusCodes.Status200OK,
                    ElapsedTime = stopWatch.ElapsedMilliseconds,
                    Data = movies,
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }

            return BadRequest();
        }

        [HttpGet]
        [Route("search/{searchtext}")]
        public async Task<IActionResult> Search(string searchtext)
        {
            try
            {
                // ------------------------------
                // clean input
                // ------------------------------
                searchtext = searchtext.Trim().ToLower();

                _logger.LogInformation($"Movie search requested with: {searchtext}");

                Stopwatch stopWatch = new();
                stopWatch.Start();

                // -----------------------------------------------------------------------------------------------------------
                // search movies, including related entities (sub entities are added automatically upon dbcontext config.)
                // -----------------------------------------------------------------------------------------------------------
                var _movies = await _service.GetAsync<Movie>(c => (c.Title.ToLower().Contains(searchtext)) ||
                                                            (c.Actors.Any(c => c.Actor.Name.ToLower().Contains(searchtext)) ||
                                                            (c.Genres.Any(c => c.Genre.Name.ToLower().Contains(searchtext)))),
                                                             o => o.OrderBy(c => c.Title), null, null, inc => inc.Actors, inc => inc.Genres);

                var movies = _mapper.Map<IEnumerable<MovieModel>>(_movies);

                stopWatch.Stop();

                if (movies == null)
                {
                    return Ok(new ResponseModel
                    {
                        Message = $"No movies found with {searchtext}",
                        StatusCode = StatusCodes.Status200OK,
                        ElapsedTime = stopWatch.ElapsedMilliseconds,
                    });
                }

                // ---------------------------------------------------------------------------------
                // here we use a generic reponse model                
                // ---------------------------------------------------------------------------------
                return Ok(new ResponseModel
                {
                    Message = $"Here is your movie results for your search: \"{searchtext}\". Found {movies.Count()}",
                    StatusCode = StatusCodes.Status200OK,
                    ElapsedTime = stopWatch.ElapsedMilliseconds,
                    Data = movies,
                });

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return BadRequest();
        }
    }
}
