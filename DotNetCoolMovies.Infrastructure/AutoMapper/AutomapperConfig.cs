using AutoMapper;
using DotNetCoolMovies.Core.Domain;
using DotNetCoolMovies.Core.Models;
using System.Linq;

namespace DotNetCoolMovies.Infrastructure.AutoMapper
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<Movie, MovieModel>()
                .ForMember(dest => dest.Actors, opt => opt.MapFrom(src => src.Actors.Select(c => new ActorModel { Id = c.ActorId, Name = c.Actor.Name })))
                .ForMember(dest => dest.Genres, opt => opt.MapFrom(src => src.Genres.Select(c => new GenreModel { Id = c.GenreId, Name = c.Genre.Name })))
                .ForMember(dest => dest.GenreListSimple, opt => opt.MapFrom(src => string.Join(", ", src.Genres.Select(c => c.Genre.Name).ToArray())))
                .ForMember(dest => dest.ActorListSimple, opt => opt.MapFrom(src => string.Join(", ", src.Actors.Select(c => c.Actor.Name).ToArray())))
                .ReverseMap();
        }
    }
}
