using System;

namespace SaveTimeCore.Web.Client.Models
{
    public class RecordCreateViewModel
    {
        public int BarberId { get; set; }
        public int ClientId { get; set; }
        public DateTime BookingTime { get; set; }
        public double SpendTime { get; set; }
        public int Status { get; set; }
    }
}
