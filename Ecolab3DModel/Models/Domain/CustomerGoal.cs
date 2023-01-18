using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Ecolab.Ecolab3D.Backend.FunctionApplication.Infrastructure.Persistence.EntityFrameworkModels
{
    public partial class CustomerGoal
    {
        public int CustomerKey { get; set; }
        public string CustomerName { get; set; }
        public double? PercentGoodRacks { get; set; }
        public int? HandWashes { get; set; }
        public int? SinkSurfaceCompleted { get; set; }
        public bool? IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
    }
}
