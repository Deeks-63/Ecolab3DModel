using AutoMapper;
using Ecolab.Ecolab3D.Backend.FunctionApplication.Infrastructure.Persistence.EntityFrameworkModels;
using Ecolab3DModel.Models.DTO;
using Ecolab3DModel.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Ecolab3DModel.Controllers
{
    [ApiController]
    [Route("CustomerGoals")]
    public class CustomerGoalsController : Controller
    {
        private readonly ICustomerGoalRepository customerGoalRepository;
        private readonly IMapper mapper;

        public CustomerGoalsController(ICustomerGoalRepository customerGoalRepository, IMapper mapper)
        {
            this.customerGoalRepository = customerGoalRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCustomerGoalsAsync()
        {
            //Fetch data from database
            var goalsDomain = await customerGoalRepository.GetAllAsync();
            //Convert domain to DTO
            var goalsDTO = mapper.Map<List<Models.DTO.CustomerGoal>>(goalsDomain);
            return Ok(goalsDTO);
        }
        [HttpPost]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateCustomerGoalsAsync([FromRoute] int id, [FromBody] Models.DTO.UpdateCustomerGoalsRequest updateCustomerGoalsRequest)
        {
            //Convert DTO to Domain
            var customerGoalDomain = new Ecolab.Ecolab3D.Backend.FunctionApplication.Infrastructure.Persistence.EntityFrameworkModels.CustomerGoal
            {
                CustomerName = updateCustomerGoalsRequest.CustomerName,
                CustomerKey = updateCustomerGoalsRequest.CustomerKey,
                IsActive = updateCustomerGoalsRequest.IsActive,
                PercentGoodRacks = updateCustomerGoalsRequest.PercentGoodRacks,
                HandWashes = updateCustomerGoalsRequest.HandWashes,
                SinkSurfaceCompleted = updateCustomerGoalsRequest.SinkSurfaceCompleted,
                CreatedDate = updateCustomerGoalsRequest.CreatedDate,
                LastModifiedDate = updateCustomerGoalsRequest.LastModifiedDate,
            };
            //Pass details to repository -> Get Domain object in response
            customerGoalDomain = await customerGoalRepository.UpdateAsync(id, customerGoalDomain);
            // if null -> return notFound
            if (customerGoalDomain == null)
            {
                return NotFound();
            }
            //Convert back to DTO
            var customerGoalDTO = new Models.DTO.CustomerGoal
            {
                CustomerKey = customerGoalDomain.CustomerKey,
                CustomerName = customerGoalDomain.CustomerName,
                IsActive = customerGoalDomain.IsActive,
                PercentGoodRacks = customerGoalDomain.PercentGoodRacks,
                HandWashes = customerGoalDomain.HandWashes,
                SinkSurfaceCompleted = customerGoalDomain.SinkSurfaceCompleted,
                CreatedDate = customerGoalDomain.CreatedDate,
                LastModifiedDate = customerGoalDomain.LastModifiedDate,
            };
            //Return
            return Ok(customerGoalDTO);
        }
    }
}
