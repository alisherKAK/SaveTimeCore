using System;

namespace SaveTimeCore.Domain.Resources
{
    public class BarberResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime WorkDayStart { get; set; }
        public DateTime WorkDayEnd { get; set; }
        public int BranchId { get; set; }
        public int AccountId { get; set; }
    }
}
