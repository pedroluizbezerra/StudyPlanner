using AutoMapper;
using StudyPlanner.API.DTO;
using StudyPlanner.Business.Models;

namespace StudyPlanner.API.Configuration
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Conhecimento, ConhecimentoDTO>()
                .ReverseMap();
        }
    }
}
