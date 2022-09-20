using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProleiT.OeeBaseClassifiers.Storage;
using MasterData.Storage.Enities;

namespace MasterData.Equipments
{
    public class EquipmentManager : IEquipmentManager
    {
        private readonly MasterDataContext _dbContext;
        private readonly IMapper _mapper;

        public EquipmentManager(MasterDataContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IReadOnlyCollection<EquipmentDto>> GetAsync()
        {
            var entities = await _dbContext.Equipments.ToListAsync();

            return entities.Select(x => _mapper.Map<EquipmentDto>(x)).ToImmutableList();
        }

        public async Task<EquipmentDto> GetById(Guid id)
        {
            var entity = await GetEntityById(id);

            return _mapper.Map<EquipmentDto>(entity);
        }

        public async Task<EquipmentDto> CreateAsync(CreateEquipmentRequest request)
        {
            await ValidateUniqueName(request.Name, request.UnitId);

            var newEntity = new Equipment
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                UnitId = request.UnitId,
                IsUsed = request.IsUsed,
                CreatedAt = DateTime.UtcNow
            };

            _dbContext.Add(newEntity);

            await _dbContext.SaveChangesAsync();

            return _mapper.Map<EquipmentDto>(newEntity);
        }

        public async Task<EquipmentDto> UpdateAsync(Guid id, UpdateEquipmentRequest request)
        {
            await ValidateUniqueName(request.Name, request.UnitId, id);

            var entity = await GetEntityById(id);

            entity.Name = request.Name;
            entity.UnitId = request.UnitId;
            entity.IsUsed = request.IsUsed;

            await _dbContext.SaveChangesAsync();

            return _mapper.Map<EquipmentDto>(entity);
        }

        public async Task<EquipmentDto> Delete(Guid id)
        {
            var entity = await GetEntityById(id);

            var result = _dbContext.Remove(entity);

            await _dbContext.SaveChangesAsync();

            return _mapper.Map<EquipmentDto>(result.Entity);
        }

        private async Task<Equipment> GetEntityById(Guid id)
        {
            var entity = await _dbContext.Equipments.FirstOrDefaultAsync(x => x.Id == id);

            if (entity == null)
                throw new Exception(
                    $"Оборудование c id == {id} не найдено");

            return entity;
        }

        private async Task ValidateUniqueName(string name, Guid unitId, Guid? id = null)
        {
            var isNameAlreadyExists = id.HasValue
                ? await _dbContext.Equipments.AnyAsync(x => x.Name == name && x.UnitId == unitId && x.Id != id) 
                : await _dbContext.Equipments.AnyAsync(x => x.Name == name && x.UnitId == unitId);

            if (isNameAlreadyExists)
            {
                throw new Exception(
                    $@"Оборудование c именем ""{name}"" уже существует");
            }
        }
    }
}
