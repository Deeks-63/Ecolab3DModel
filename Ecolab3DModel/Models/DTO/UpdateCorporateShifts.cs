namespace Ecolab3DModel.Models.DTO
{
    public class UpdateCorporateShifts
    {
        public int CustomerKey { get; set; }
        public string ShiftDayOfWeek { get; set; }
        public int ShiftEnumeration { get; set; }
        public string ShiftName { get; set; }
        public ShiftTime? StartTime { get; set; }
        public ShiftTime? EndTime { get; set; }
        public int? NumberOfWorkers { get; set; }
        public bool? IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
    }

    public class ShiftTime
    {
        public int Hour { get; set;}
        public int Minute { get; set; }
    }
}
