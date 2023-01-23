namespace Ecolab3DModel.Models.DTO
{
    public class UpdateCustomerGoalsRequest
    {
        //public int Id { get; set; }
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
