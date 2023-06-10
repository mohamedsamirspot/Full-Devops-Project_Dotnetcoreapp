using AutoMapper;
using NewsSite.Models;
using NewsSite.Models.Dto;


namespace NewsSite
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<News, NewsDto>().ReverseMap();
            //CreateMap<NewsDto, News>();
        }
    }
}
