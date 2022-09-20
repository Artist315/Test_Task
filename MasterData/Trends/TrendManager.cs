using AutoMapper;
using MasterData.Storage.Enities;
using Microsoft.EntityFrameworkCore;
using ProleiT.OeeBaseClassifiers.Storage;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;

namespace MasterData.Trends
{
    public class TrendManager : ITrendManager
    {
        private readonly MasterDataContext _dbContext;
        private readonly IMapper _mapper;

        public TrendManager(MasterDataContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IReadOnlyCollection<TrendDto>> GetAsync()
        {
            var entities = await _dbContext.Trend.ToListAsync();

            return entities.Select(x => _mapper.Map<TrendDto>(x)).ToImmutableList();
        }

        public async Task<TrendDto> GetByIdAsync(Guid id)
        {
            var entity = await GetEntityById(id);

            return _mapper.Map<TrendDto>(entity);
        }

        public async Task<TrendDto> CreateAsync(CreateTrendRequest request)
        {
            await ValidateUniqueName(request.Name);

            var newEntity = new Trend
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                EquipmentId = request.EquipmentId,
                UnitId = request.UnitId,
                CreatedAt = DateTime.UtcNow
            };

            _dbContext.Add(newEntity);

            await _dbContext.SaveChangesAsync();

            return _mapper.Map<TrendDto>(newEntity);
        }

        public async Task<TrendDto> UpdateAsync(Guid id, UpdateTrendRequest request)
        {
            await ValidateUniqueName(request.Name, id);

            var entity = await GetEntityById(id);

            entity.Name = request.Name;
            entity.EquipmentId = request.EquipmentId;
            entity.UnitId = request.UnitId;

            await _dbContext.SaveChangesAsync();

            return _mapper.Map<TrendDto>(entity);
        }

        public async Task<TrendDto> Delete(Guid id)
        {
            var entity = await GetEntityById(id);

            var result = _dbContext.Remove(entity);

            await _dbContext.SaveChangesAsync();

            return _mapper.Map<TrendDto>(result.Entity);
        }

        private async Task<Trend> GetEntityById(Guid id)
        {
            var entity = await _dbContext.Trend.FirstOrDefaultAsync(x => x.Id == id);

            if (entity == null)
            {
                throw new Exception($"Trend c id == {id} не найден");
            }

            return entity;
        }

        private async Task ValidateUniqueName(string name, Guid? id = null)
        {
            bool isNameAlreadyExists;

            if (id.HasValue)
            {
                isNameAlreadyExists = await _dbContext.Trend.AnyAsync(x => x.Name == name && x.Id != id);
            }
            else
            {
                isNameAlreadyExists = await _dbContext.Trend.AnyAsync(x => x.Name == name);
            }

            if (isNameAlreadyExists)
            {
                throw new Exception( $@"Trend списка материалов c именем ""{name}"" уже существует");
            }
        }
    }
}
