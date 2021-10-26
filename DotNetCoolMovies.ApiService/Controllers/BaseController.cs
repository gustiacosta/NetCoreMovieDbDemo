using AutoMapper;
using DotNetCoolMovies.Data.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace DotNetCoolMovies.ApiService.Controllers
{
    public class BaseController : Controller
    {
        internal IMapper _mapper;
        internal IBusinessLogicService _service;
        //internal IConfiguration _configuration;
        internal IHttpClientFactory _httpClientFactory;
    }
}
