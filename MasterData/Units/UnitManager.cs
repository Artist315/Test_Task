using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProleiT.OeeBaseClassifiers.Storage;
using MasterData.Storage.Enities;

namespace MasterData.Units
{
    public class UnitManager : IUnitManager
    {
        private readonly MasterDataContext _dbContext;
        private readonly IMapper _mapper;

        public UnitManager(MasterDataContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IReadOnlyCollection<UnitDto>> GetAsync()
        {
            var entities = await _dbContext.Units.ToListAsync();

            return entities.Select(x => _mapper.Map<UnitDto>(x)).ToImmutableList();
        }

        public async Task<UnitDto> GetById(Guid id)
        {
            var entity = await GetEntityById(id);

            return _mapper.Map<UnitDto>(entity);
        }

        public async Task<UnitDto> CreateAsync(CreateUnitRequest request)
        {
            await ValidateUniqueName(request.Name);

            var newEntity = new Unit
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Type = request.Type,
                CreatedAt = DateTime.UtcNow
            };

            _dbContext.Add(newEntity);

            await _dbContext.SaveChangesAsync();

            return _mapper.Map<UnitDto>(newEntity);
        }

        public async Task<UnitDto> UpdateAsync(Guid id, UpdateUnitRequest request)
        {
            await ValidateUniqueName(request.Name, id);

            var entity = await GetEntityById(id);

            entity.Name = request.Name;
            entity.Type = request.Type;

            await _dbContext.SaveChangesAsync();

            return _mapper.Map<UnitDto>(entity);
        }

        public async Task<UnitDto> Delete(Guid id)
        {
            var entity = await GetEntityById(id);

            var result = _dbContext.Remove(entity);

            await _dbContext.SaveChangesAsync();

            return _mapper.Map<UnitDto>(result.Entity);
        }

        private async Task<Unit> GetEntityById(Guid id)
        {
            var entity = await _dbContext.Units.FirstOrDefaultAsync(x => x.Id == id);

            if (entity == null)
            {
                throw new Exception($"Производственный блок c id == {id} не найден");
            }

            return entity;
        }

        private async Task ValidateUniqueName(string name, Guid? id = null)
        {
            var isNameAlreadyExists = id.HasValue
                ? await _dbContext.Units.AnyAsync(x => x.Name == name && x.Id != id)
                : await _dbContext.Units.AnyAsync(x => x.Name == name);

            if (isNameAlreadyExists)
            {
                throw new Exception(
                    $@"Производственный блок c именем ""{name}"" уже существует");
            }
        }
    }
}
