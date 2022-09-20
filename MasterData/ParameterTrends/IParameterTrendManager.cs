using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MasterData.ParameterTrends
{
    public interface IParameterTrendManager
    {
        Task<ParameterTrendDto> CreateAsync(CreateParameterTrendRequest request);
        Task<ParameterTrendDto> Delete(Guid id);
        Task<IReadOnlyCollection<ParameterTrendDto>> GetAsync();
        Task<ParameterTrendDto> GetByIdAsync(Guid id);
        Task<ParameterTrendDto> UpdateAsync(Guid id, UpdateParameterTrendRequest request);
    }
}
