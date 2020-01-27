using System;

namespace SaveTimeCore.Web.Admin.Models
{
    public class BranchCreateViewModel
    {
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime StartWork { get; set; }
        public DateTime EndWork { get; set; }
        public int CompanyId { get; set; }
    }
}
