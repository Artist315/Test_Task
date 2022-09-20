using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.Immutable;
using MasterData.Storage.Enities;
using ProleiT.OeeBaseClassifiers.Storage;

namespace MasterData.ParameterTrends
{
    public class ParameterTrendManager : IParameterTrendManager
    {
        private readonly MasterDataContext _dbContext;
        private readonly IMapper _mapper;

        public ParameterTrendManager(MasterDataContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IReadOnlyCollection<ParameterTrendDto>> GetAsync()
        {
            var entities = await _dbContext.ParameterTrend.ToListAsync();

            return entities.Select(x => _mapper.Map<ParameterTrendDto>(x)).ToImmutableList();
        }

        public async Task<ParameterTrendDto> GetByIdAsync(Guid id)
        {
            var entity = await GetEntityById(id);

            return _mapper.Map<ParameterTrendDto>(entity);
        }

        public async Task<ParameterTrendDto> CreateAsync(CreateParameterTrendRequest request)
        {
            await ValidateUniqueName(request.Name);

            var newEntity = new ParameterTrend
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                TrendId = request.TrendId,
                RecordMode = request.RecordMode,
                CreatedAt = DateTime.UtcNow
            };

            _dbContext.Add(newEntity);

            await _dbContext.SaveChangesAsync();

            return _mapper.Map<ParameterTrendDto>(newEntity);
        }

        public async Task<ParameterTrendDto> UpdateAsync(Guid id, UpdateParameterTrendRequest request)
        {
            await ValidateUniqueName(request.Name, id);

            var entity = await GetEntityById(id);

            entity.Name = request.Name;
            entity.TrendId = request.TrendId;
            entity.RecordMode = request.RecordMode;

            await _dbContext.SaveChangesAsync();

            return _mapper.Map<ParameterTrendDto>(entity);
        }

        public async Task<ParameterTrendDto> Delete(Guid id)
        {
            var entity = await GetEntityById(id);

            var result = _dbContext.Remove(entity);

            await _dbContext.SaveChangesAsync();

            return _mapper.Map<ParameterTrendDto>(result.Entity);
        }

        private async Task<ParameterTrend> GetEntityById(Guid id)
        {
            var entity = await _dbContext.ParameterTrend.FirstOrDefaultAsync(x => x.Id == id);

            if (entity == null)
            {
                throw new Exception($"ParameterTrend c id == {id} не найден");
            }

            return entity;
        }

        private async Task ValidateUniqueName(string name, Guid? id = null)
        {
            bool isNameAlreadyExists;

            if (id.HasValue)
            {
                isNameAlreadyExists = await _dbContext.ParameterTrend.AnyAsync(x => x.Name == name && x.Id != id);
            }
            else
            {
                isNameAlreadyExists = await _dbContext.ParameterTrend.AnyAsync(x => x.Name == name);
            }

            if (isNameAlreadyExists)
            {
                throw new Exception($@"ParameterTrend c именем ""{name}"" уже существует");
            }
        }
    }
}
