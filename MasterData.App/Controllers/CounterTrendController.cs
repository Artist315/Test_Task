using FluentValidation;
using MasterData.CounterTrends;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace VS.Oee.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CounterTrendController : ControllerBase
    {
        private readonly ICounterTrendManager _entityManager;
        private readonly IValidator<CreateCounterTrendRequest> _validatorOfCreateRequest;
        private readonly IValidator<UpdateCounterTrendRequest> _validatorOfUpdateRequest;

        public CounterTrendController(
            ICounterTrendManager entityManager
            , IValidator<CreateCounterTrendRequest> validatorOfCreateRequest
            , IValidator<UpdateCounterTrendRequest> validatorOfUpdateRequest)
        {
            _entityManager = entityManager;
            _validatorOfCreateRequest = validatorOfCreateRequest;
            _validatorOfUpdateRequest = validatorOfUpdateRequest;
        }

        [HttpGet]
        public async Task<IReadOnlyCollection<CounterTrendDto>> GetAsync()
        {
            return await _entityManager.GetAsync();
        }

        [HttpGet("{id:guid}")]
        public async Task<CounterTrendDto> GetByIdAsync(Guid id)
        {
            return await _entityManager.GetByIdAsync(id);
        }


        [HttpPost, Consumes("application/json")]
        public async Task<CounterTrendDto> CreateAsync([FromBody] CreateCounterTrendRequest request)
        {
            await _validatorOfCreateRequest.ValidateAndThrowAsync(request);

            return await _entityManager.CreateAsync(request);
        }


        [HttpPut("{id:guid}"), Consumes("application/json")]
        public async Task<CounterTrendDto> UpdateAsync(Guid id, [FromBody] UpdateCounterTrendRequest request)
        {
            await _validatorOfUpdateRequest.ValidateAndThrowAsync(request);
            return await _entityManager.UpdateAsync(id, request);
        }


        [HttpDelete("{id:guid}")]
        public async Task<CounterTrendDto> Delete(Guid id)
        {
            return await _entityManager.Delete(id);
        }
    }
}
