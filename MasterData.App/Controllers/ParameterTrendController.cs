using FluentValidation;
using MasterData.ParameterTrends;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace VS.Oee.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParameterTrendController : ControllerBase
    {
        private readonly IParameterTrendManager _entityManager;
        private readonly IValidator<CreateParameterTrendRequest> _validatorOfCreateRequest;
        private readonly IValidator<UpdateParameterTrendRequest> _validatorOfUpdateRequest;

        public ParameterTrendController(
            IParameterTrendManager entityManager
            , IValidator<CreateParameterTrendRequest> validatorOfCreateRequest
            , IValidator<UpdateParameterTrendRequest> validatorOfUpdateRequest)
        {
            _entityManager = entityManager;
            _validatorOfCreateRequest = validatorOfCreateRequest;
            _validatorOfUpdateRequest = validatorOfUpdateRequest;
        }

        [HttpGet]
        public async Task<IReadOnlyCollection<ParameterTrendDto>> GetAsync()
        {
            return await _entityManager.GetAsync();
        }

        [HttpGet("{id:guid}")]
        public async Task<ParameterTrendDto> GetByIdAsync(Guid id)
        {
            return await _entityManager.GetByIdAsync(id);
        }

        [HttpPost, Consumes("application/json")]
        public async Task<ParameterTrendDto> CreateAsync([FromBody] CreateParameterTrendRequest request)
        {
            await _validatorOfCreateRequest.ValidateAndThrowAsync(request);

            return await _entityManager.CreateAsync(request);
        }

        [HttpPut("{id:guid}"), Consumes("application/json")]
        public async Task<ParameterTrendDto> UpdateAsync(Guid id, [FromBody] UpdateParameterTrendRequest request)
        {
            await _validatorOfUpdateRequest.ValidateAndThrowAsync(request);
            return await _entityManager.UpdateAsync(id, request);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ParameterTrendDto> Delete(Guid id)
        {
            return await _entityManager.Delete(id);
        }
    }
}
