using AutoMapper;
using MasterData.Storage.Enities;

namespace MasterData.ParameterTrends
{
    public class ParameterTrendMappingProfile : Profile
    {
        public ParameterTrendMappingProfile() { CreateMap<ParameterTrend, ParameterTrendDto>(); }
    }
}
