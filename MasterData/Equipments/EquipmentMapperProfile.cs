using AutoMapper;
using MasterData.Storage.Enities;

namespace MasterData.Equipments
{
    public class EquipmentMapperProfile : Profile
    {
        public EquipmentMapperProfile() { CreateMap<Equipment, EquipmentDto>(); }
    }
}
