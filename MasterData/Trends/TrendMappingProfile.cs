using AutoMapper;
using MasterData.Storage.Enities;
namespace MasterData.Trends
{
    public class TrendMappingProfile : Profile
    {
        public TrendMappingProfile() { CreateMap<Trend, TrendDto>(); }
    }
}
