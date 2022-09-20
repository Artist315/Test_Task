using AutoMapper;
using MasterData.Storage.Enities;

namespace MasterData.CounterTrends
{
    public class TrendMappingProfile : Profile
    {
        public TrendMappingProfile() { CreateMap<CounterTrend, CounterTrendDto>(); }
    }
}
