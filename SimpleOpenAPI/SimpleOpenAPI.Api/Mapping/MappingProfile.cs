using AutoMapper;
using SimpleOpenAPI.Api.Contracts.V1.Requests;
using SimpleOpenAPI.Api.Contracts.V1.Resources;
using SimpleOpenAPI.Domain.Models;

namespace SimpleOpenAPI.Api.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to Resource
            CreateMap<Book, BookResource>();
            
            // Resource to Domain
            CreateMap<BookResource, Book>();
            CreateMap<AddBookRequest, Book>();
            CreateMap<UpdateBookRequest, Book>();
        }
    }
}