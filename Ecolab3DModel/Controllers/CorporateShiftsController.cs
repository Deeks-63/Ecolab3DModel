using Ecolab.Ecolab3D.Backend.FunctionApplication.Infrastructure.Persistence.EntityFrameworkModels;
using Microsoft.AspNetCore.Mvc;

namespace Ecolab3DModel.Controllers
{
    [ApiController]
    [Route("CorporateShifts")]
    public class CorporateShiftsController : Controller
    {
        [HttpGet]
        public IActionResult GetAllCorporateShifts()
        {
            var corporateShifts = new List<CorporateShifts>()
            {
                new CorporateShifts
                {
                    CustomerKey = 11,
                    ShiftDayOfWeek = "M,Tu",
                    ShiftEnumeration = 4,
                    ShiftName="AM",
                    StartTime= DateTime.UtcNow.TimeOfDay,
                    EndTime = DateTime.UtcNow.AddHours(5).TimeOfDay,
                    NumberOfWorkers=4,
                    IsActive=true
                },
                new CorporateShifts
                {
                   CustomerKey = 12,
                    ShiftDayOfWeek = "M,Tu,W",
                    ShiftEnumeration = 2,
                    ShiftName="PM",
                    StartTime=DateTime.UtcNow.TimeOfDay,
                    EndTime = DateTime.UtcNow.AddHours(6).TimeOfDay,
                   NumberOfWorkers=8,
                    IsActive=true
                },
            };
            return Ok(corporateShifts);
        }
    }
}
