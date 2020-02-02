using System;

namespace SaveTimeCore.Domain.Resources
{
    public class RecordResource
    {
        public int Id { get; set; }
        public int BarberId { get; set; }
        public int ClientId { get; set; }
        public DateTime BookingTime { get; set; }
        public double SpendTime { get; set; }
    }
}
