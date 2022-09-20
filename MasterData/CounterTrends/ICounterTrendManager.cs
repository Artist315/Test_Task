using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MasterData.CounterTrends
{
    public interface ICounterTrendManager
    {
        Task<CounterTrendDto> CreateAsync(CreateCounterTrendRequest request);
        Task<CounterTrendDto> Delete(Guid id);
        Task<IReadOnlyCollection<CounterTrendDto>> GetAsync();
        Task<CounterTrendDto> GetByIdAsync(Guid id);
        Task<CounterTrendDto> UpdateAsync(Guid id, UpdateCounterTrendRequest request);
    }
}
