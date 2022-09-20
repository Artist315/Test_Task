using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentValidation;
using MasterData.Equipments;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ProleiT.OeeBaseClassifiers.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipmentController : ControllerBase
    {
        private readonly IEquipmentManager _entityManager;
        private readonly IValidator<CreateEquipmentRequest> _validatorOfCreateRequest;
        private readonly IValidator<UpdateEquipmentRequest> _validatorOfUpdateRequest;

        public EquipmentController(
            IEquipmentManager entityManager,
            IValidator<CreateEquipmentRequest> validatorOfCreateRequest,
            IValidator<UpdateEquipmentRequest> validatorOfUpdateRequest)
        {
            _entityManager = entityManager;
            _validatorOfCreateRequest = validatorOfCreateRequest;
            _validatorOfUpdateRequest = validatorOfUpdateRequest;
        }


        [HttpGet]
        public async Task<IReadOnlyCollection<EquipmentDto>> GetAsync()
        {
            return await _entityManager.GetAsync();
        }


        [HttpPost, Consumes("application/json")]
        public async Task<EquipmentDto> CreateAsync([FromBody] CreateEquipmentRequest request)
        {
            await _validatorOfCreateRequest.ValidateAndThrowAsync(request);

            return await _entityManager.CreateAsync(request);
        }


        [HttpPut("{id:guid}"), Consumes("application/json")]
        public async Task<EquipmentDto>  UpdateAsync(Guid id, [FromBody] UpdateEquipmentRequest request)
        {
            await _validatorOfUpdateRequest.ValidateAndThrowAsync(request);

            return await _entityManager.UpdateAsync(id, request);
        }


        [HttpDelete("{id:guid}")]
        public async Task<EquipmentDto> Delete(Guid id)
        {
            return await _entityManager.Delete(id);
        }
    }
}