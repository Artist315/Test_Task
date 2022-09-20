using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MasterData.Equipments
{
    public interface IEquipmentManager
    {
        Task<IReadOnlyCollection<EquipmentDto>> GetAsync();
        Task<EquipmentDto> GetById(Guid id);
        Task<EquipmentDto> CreateAsync(CreateEquipmentRequest request);
        Task<EquipmentDto> UpdateAsync(Guid id, UpdateEquipmentRequest request);
        Task<EquipmentDto> Delete(Guid id);
    }
}
