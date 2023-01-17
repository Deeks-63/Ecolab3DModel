using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Ecolab.Ecolab3D.Backend.FunctionApplication.Infrastructure.Persistence.EntityFrameworkModels
{
    public partial class CorporateShifts
    {
        [Key]
        public int CustomerKey { get; set; }
        public string ShiftDayOfWeek { get; set; }
        public int ShiftEnumeration { get; set; }
        public string ShiftName { get; set; }
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }
        public int? NumberOfWorkers { get; set; }
        public bool? IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
    }
}
