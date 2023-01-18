using AutoMapper;
using Ecolab.Ecolab3D.Backend.FunctionApplication.Infrastructure.Persistence.EntityFrameworkModels;
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
        public async Task<IActionResult> GetAllCorporateShifts()
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
    }
}
