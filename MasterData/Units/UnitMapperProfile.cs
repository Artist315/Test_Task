using AutoMapper;
using MasterData.Storage.Enities;

namespace MasterData.Units
{
    public class UnitMapperProfile : Profile
    {
        public UnitMapperProfile() { CreateMap<Unit, UnitDto>(); }
    }
}
