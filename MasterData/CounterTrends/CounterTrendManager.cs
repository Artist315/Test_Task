using AutoMapper;
using MasterData.Storage.Enities;
using Microsoft.EntityFrameworkCore;
using ProleiT.OeeBaseClassifiers.Storage;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;

namespace MasterData.CounterTrends
{
    public class CounterTrendManager : ICounterTrendManager
    {
        private readonly MasterDataContext _dbContext;
        private readonly IMapper _mapper;

        public CounterTrendManager(MasterDataContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IReadOnlyCollection<CounterTrendDto>> GetAsync()
        {
            var entities = await _dbContext.CounterTrend.ToListAsync();

            return entities.Select(x => _mapper.Map<CounterTrendDto>(x)).ToImmutableList();
        }

        public async Task<CounterTrendDto> GetByIdAsync(Guid id)
        {
            var entity = await GetEntityById(id);

            return _mapper.Map<CounterTrendDto>(entity);
        }

        public async Task<CounterTrendDto> CreateAsync(CreateCounterTrendRequest request)
        {
            await ValidateUniqueName(request.Name);

            var newEntity = new CounterTrend
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                TrendId = request.TrendId,
                Type = request.Type,
                CreatedAt = DateTime.UtcNow,
                RecordMode = request.RecordMode,
            };

            _dbContext.Add(newEntity);

            await _dbContext.SaveChangesAsync();

            return _mapper.Map<CounterTrendDto>(newEntity);
        }

        public async Task<CounterTrendDto> UpdateAsync(Guid id, UpdateCounterTrendRequest request)
        {
            await ValidateUniqueName(request.Name, id);

            var entity = await GetEntityById(id);

            entity.Name = request.Name;
            entity.TrendId = request.TrendId;
            entity.Type = request.Type;
            entity.RecordMode = request.RecordMode;

            await _dbContext.SaveChangesAsync();

            return _mapper.Map<CounterTrendDto>(entity);
        }

        public async Task<CounterTrendDto> Delete(Guid id)
        {
            CounterTrend entity = await GetEntityById(id);

            var result = _dbContext.Remove(entity);

            await _dbContext.SaveChangesAsync();

            return _mapper.Map<CounterTrendDto>(result.Entity);
        }

        private async Task<CounterTrend> GetEntityById(Guid id)
        {
            var entity = await _dbContext.CounterTrend.FirstOrDefaultAsync(x => x.Id == id);

            if (entity == null)
            {
                throw new Exception($"CounterTrend c id == {id} не найден");
            }

            return entity;
        }

        private async Task ValidateUniqueName(string name, Guid? id = null)
        {
            bool isNameAlreadyExists;

            if (id.HasValue)
            {
                isNameAlreadyExists = await _dbContext.CounterTrend.AnyAsync(x => x.Name == name && x.Id != id);
            }
            else
            {
                isNameAlreadyExists = await _dbContext.CounterTrend.AnyAsync(x => x.Name == name);
            }

            if (isNameAlreadyExists)
            {
                throw new Exception($@"CounterTrend c именем ""{name}"" уже существует");
            }
        }
    }
}
