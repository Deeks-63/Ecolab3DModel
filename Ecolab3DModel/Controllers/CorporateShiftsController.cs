using AutoMapper;
using Ecolab.Ecolab3D.Backend.FunctionApplication.Infrastructure.Persistence.EntityFrameworkModels;
using Ecolab3DModel.Models.DTO;
using Ecolab3DModel.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Ecolab3DModel.Controllers
{
    [ApiController]
    [Route("CorporateShifts")]
    public class CorporateShiftsController : Controller
    {
        private readonly ICorporateShiftsServices corporateShifts;
        private readonly IMapper mapper;

        public CorporateShiftsController(ICorporateShiftsServices corporateShifts, IMapper mapper)
        {
            this.corporateShifts = corporateShifts;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCorporateShiftsAsync()
        {
            var shifts = await corporateShifts.GetAllAsync();

            //return DTO corporateShifts
            //var corporateShiftsDTO = new List<Models.DTO.CorporateShifts>();
            //shifts.ToList().ForEach(shift =>
            //{
            //    var corporateDTO = new Models.DTO.CorporateShifts()
            //    {
            //        CustomerKey= shift.CustomerKey,
            //        ShiftDayOfWeek= shift.ShiftDayOfWeek,
            //        ShiftEnumeration= shift.ShiftEnumeration,  
            //        StartTime= shift.StartTime,
            //        EndTime= shift.EndTime,
            //        ShiftName= shift.ShiftName,
            //        NumberOfWorkers= shift.NumberOfWorkers,
            //        IsActive= shift.IsActive,
            //        CreatedDate= shift.CreatedDate,
            //        LastModifiedDate= shift.LastModifiedDate
            //    };
            //    corporateShiftsDTO.Add(corporateDTO);
            //});
            var shiftsDTO = mapper.Map<List<Models.DTO.CorporateShifts>>(shifts);
            return Ok(shiftsDTO);
        }

        [HttpGet]
        [Route("{CustomerKey:int}")]
        public async Task<IActionResult> GetCorporateShiftAsync(int CustomerKey)
        {
            var customer = await corporateShifts.GetAsync(CustomerKey);
            if(customer == null)
            {
                return NotFound();
            }
            var customerDTO = mapper.Map<IEnumerable<Models.DTO.CorporateShifts>>(customer);
            //In above line customer is the source and <odels.DTO.corporateshifts is the destination.
            return Ok(customerDTO);
        }

        [HttpPut]
        [Route("{CustomerKey:int}")]
        public async Task<IActionResult> UpdateCorporateShiftAsync([FromRoute] int CustomerKey, [FromBody] Models.DTO.UpdateCorporateShifts updateCorporateShifts)
        {
            //Convert DTO to Domain
            var customer = new Ecolab.Ecolab3D.Backend.FunctionApplication.Infrastructure.Persistence.EntityFrameworkModels.CorporateShifts
            {
                ShiftDayOfWeek = updateCorporateShifts.ShiftDayOfWeek,
                ShiftEnumeration = updateCorporateShifts.ShiftEnumeration,
                CreatedDate = updateCorporateShifts.CreatedDate,
                StartTime = new TimeSpan(updateCorporateShifts.StartTime.Hour, updateCorporateShifts.StartTime.Minute,0),
                EndTime = new TimeSpan(updateCorporateShifts.EndTime.Hour, updateCorporateShifts.EndTime.Minute, 0),
                IsActive = updateCorporateShifts.IsActive,
                LastModifiedDate = updateCorporateShifts.LastModifiedDate,
                NumberOfWorkers = updateCorporateShifts.NumberOfWorkers,
                ShiftName = updateCorporateShifts.ShiftName
            };
            //Update corporateshift using repository
            customer = await corporateShifts.UpdateAsync(CustomerKey, customer);
            //if null -> not found
            if(customer == null)
            {
                return NotFound();
            }
            //Convert back domain to DTO
            var customerDTO = new Models.DTO.CorporateShifts
            {
                ShiftDayOfWeek = customer.ShiftDayOfWeek,
                ShiftEnumeration = customer.ShiftEnumeration,
                CreatedDate = customer.CreatedDate,
                StartTime = customer.StartTime,
                EndTime = customer.EndTime,
                IsActive = customer.IsActive,
                LastModifiedDate = customer.LastModifiedDate,
                NumberOfWorkers = customer.NumberOfWorkers,
                ShiftName = customer.ShiftName
            };
            //Return OK
            return Ok(customerDTO);
        }
    }
}
