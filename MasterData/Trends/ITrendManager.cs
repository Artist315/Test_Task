using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MasterData.Trends
{
    public interface ITrendManager
    {
        Task<TrendDto> CreateAsync(CreateTrendRequest request);
        Task<TrendDto> Delete(Guid id);
        Task<IReadOnlyCollection<TrendDto>> GetAsync();
        Task<TrendDto> GetByIdAsync(Guid id);
        Task<TrendDto> UpdateAsync(Guid id, UpdateTrendRequest request);
    }
}
