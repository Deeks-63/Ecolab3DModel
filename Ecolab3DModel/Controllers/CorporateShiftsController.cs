using AutoMapper;
using Ecolab.Ecolab3D.Backend.FunctionApplication.Infrastructure.Persistence.EntityFrameworkModels;
using Ecolab3DModel.Data;
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
        [Route("{Id:int}")]
        public async Task<IActionResult> GetCorporateShiftAsync(int Id)
        {
            var customer = await corporateShifts.GetAsync(Id);
            if(customer == null)
            {
                return NotFound();
            }
            var customerDTO = mapper.Map<IEnumerable<Models.DTO.CorporateShifts>>(customer);
            //In above line customer is the source and <odels.DTO.corporateshifts is the destination.
            return Ok(customerDTO);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCorporateShiftAsync([FromRoute]int Id, [FromBody] IEnumerable<Models.DTO.UpdateCorporateShifts> updateCorporateShifts)
        {
            //Convert DTO to Domain
            var customer = updateCorporateShifts.Select(o=> new Ecolab.Ecolab3D.Backend.FunctionApplication.Infrastructure.Persistence.EntityFrameworkModels.CorporateShifts
            {
                ShiftDayOfWeek = o.ShiftDayOfWeek,
                ShiftEnumeration = o.ShiftEnumeration,
                CreatedDate = o.CreatedDate,
                StartTime = new TimeSpan(o.StartTime.Hour, o.StartTime.Minute,0),
                EndTime = new TimeSpan(o.EndTime.Hour, o.EndTime.Minute, 0),
                IsActive = o.IsActive,
                LastModifiedDate = o.LastModifiedDate,
                NumberOfWorkers = o.NumberOfWorkers,
                ShiftName = o.ShiftName,
                CustomerKey = o.CustomerKey
            });
            //Update corporateshift using repository
            customer = await corporateShifts.UpdateAsync(Id,customer);
            //if null -> not found
            if(customer == null)
            {
                return NotFound();
            }
            return Ok();
        }
        
        [HttpDelete]
        [Route("{Id:int}")]
        public async Task<IActionResult> DeleteCorporateShiftAsync(int Id)
        {
            //Get the shift from the database
            var shift = await corporateShifts.DeleteAsync(Id);
            //If not found return notFound
            if(shift == null)
            {
                return NotFound();
            }
            //Convert response back to DTO
            var shiftDTO = new Models.DTO.CorporateShifts
            {
                ShiftDayOfWeek= shift.ShiftDayOfWeek,
                ShiftEnumeration = shift.ShiftEnumeration,
                CreatedDate = shift.CreatedDate,
                LastModifiedDate= shift.LastModifiedDate,
                StartTime = shift.StartTime,
                EndTime = shift.EndTime,
                IsActive = shift.IsActive,
                NumberOfWorkers = shift.NumberOfWorkers,
                ShiftName = shift.ShiftName,
            };
            //return OK response
            return Ok(shiftDTO);
        }

    }
}
