using FluentValidation;
using MasterData.Trends;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace VS.Oee.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrendController : ControllerBase
    {
        private readonly ITrendManager _entityManager;
        private readonly IValidator<CreateTrendRequest> _validatorOfCreateRequest;
        private readonly IValidator<UpdateTrendRequest> _validatorOfUpdateRequest;

        public TrendController(
            ITrendManager entityManager
            , IValidator<CreateTrendRequest> validatorOfCreateRequest
            , IValidator<UpdateTrendRequest> validatorOfUpdateRequest)
        {
            _entityManager = entityManager;
            _validatorOfCreateRequest = validatorOfCreateRequest;
            _validatorOfUpdateRequest = validatorOfUpdateRequest;
        }

        [HttpGet]
        public async Task<IReadOnlyCollection<TrendDto>> GetAsync()
        {
            return await _entityManager.GetAsync();
        }

        [HttpGet("{id:guid}")]
        public async Task<TrendDto> GetByIdAsync(Guid id)
        {
            return await _entityManager.GetByIdAsync(id);
        }

        [HttpPost, Consumes("application/json")]
        public async Task<TrendDto> CreateAsync([FromBody] CreateTrendRequest request)
        {
            await _validatorOfCreateRequest.ValidateAndThrowAsync(request);

            return await _entityManager.CreateAsync(request);
        }

        [HttpPut("{id:guid}"), Consumes("application/json")]
        public async Task<TrendDto> UpdateAsync(Guid id, [FromBody] UpdateTrendRequest request)
        {
            await _validatorOfUpdateRequest.ValidateAndThrowAsync(request);

            return await _entityManager.UpdateAsync(id, request);
        }

        [HttpDelete("{id:guid}")]
        public async Task<TrendDto> Delete(Guid id)
        {
            return await _entityManager.Delete(id);
        }
    }
}
