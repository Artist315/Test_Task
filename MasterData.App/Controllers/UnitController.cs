using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentValidation;
using MasterData.Units;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ProleiT.OeeBaseClassifiers.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnitController : ControllerBase
    {
        private readonly IUnitManager _entityManager;
        private readonly IValidator<CreateUnitRequest> _validatorOfCreateRequest;
        private readonly IValidator<UpdateUnitRequest> _validatorOfUpdateRequest;

        public UnitController(
            IUnitManager entityManager, 
            IValidator<CreateUnitRequest> validatorOfCreateRequest, 
            IValidator<UpdateUnitRequest> validatorOfUpdateRequest)
        {
            _entityManager = entityManager;
            _validatorOfCreateRequest = validatorOfCreateRequest;
            _validatorOfUpdateRequest = validatorOfUpdateRequest;
        }


        [HttpGet]
        public async Task<IReadOnlyCollection<UnitDto>> GetAsync()
        {
            return await _entityManager.GetAsync();
        }

        [HttpPost, Consumes("application/json")]
        public async Task<UnitDto> CreateAsync([FromBody] CreateUnitRequest request)
        {
            await _validatorOfCreateRequest.ValidateAndThrowAsync(request);

            return await _entityManager.CreateAsync(request);
        }

        [HttpPut("{id:guid}"), Consumes("application/json")]
        public async Task<UnitDto> UpdateAsync(Guid id, [FromBody] UpdateUnitRequest request)
        {
            await _validatorOfUpdateRequest.ValidateAndThrowAsync(request);
            return await _entityManager.UpdateAsync(id, request);
        }

        [HttpDelete("{id:guid}")]
        public async Task<UnitDto> Delete(Guid id)
        {
            return await _entityManager.Delete(id);
        }
    }
}