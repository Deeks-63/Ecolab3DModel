using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Ecolab.Ecolab3D.Backend.FunctionApplication.Infrastructure.Persistence.EntityFrameworkModels
{
    public partial class ServiceAreaShifts
    {
        public int CustomerKey { get; set; }
        public string CdmsiteKey { get; set; }
        public double? TimeZone { get; set; }
        public string AccountNumber { get; set; }
        public string AccountName { get; set; }
        public string ServiceAreaId { get; set; }
        public string ServiceAreaName { get; set; }
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
