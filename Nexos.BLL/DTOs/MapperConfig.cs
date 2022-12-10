using AutoMapper;
using Nexos.DAL.Models;

namespace Nexos.BLL.DTOs
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<Author, AuthorDTO>().ReverseMap();
            CreateMap<Bookss, BookssDTO>().ReverseMap();
            CreateMap<Record, RecordDTO>().ReverseMap();
        }
    }
}