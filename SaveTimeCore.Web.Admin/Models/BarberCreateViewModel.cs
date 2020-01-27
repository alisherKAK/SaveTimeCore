using System;

namespace SaveTimeCore.Web.Admin.Models
{
    public class BarberCreateViewModel
    {
        public string Name { get; set; }
        public DateTime WorkDayStart { get; set; }
        public DateTime WorkDayEnd { get; set; }
        public int BranchId { get; set; }
        public int AccountId { get; set; }
    }
}
