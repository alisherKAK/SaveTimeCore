using System;

namespace SaveTimeCore.Domain.DTOs
{
    public class BranchDTO
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime StartWork { get; set; }
        public DateTime EndWork { get; set; }
        public int CompanyId { get; set; }
    }
}
