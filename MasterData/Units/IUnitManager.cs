using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MasterData.Units
{
    public interface IUnitManager
    {
        Task<IReadOnlyCollection<UnitDto>> GetAsync();
        Task<UnitDto> GetById(Guid id);
        Task<UnitDto> CreateAsync(CreateUnitRequest request);
        Task<UnitDto> UpdateAsync(Guid id, UpdateUnitRequest request);
        Task<UnitDto> Delete(Guid id);
    }
}
