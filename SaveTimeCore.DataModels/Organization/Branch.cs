using SaveTimeCore.AbstractModels.Marker;
using System;
using System.Collections.Generic;

namespace SaveTimeCore.DataModels.Organization
{
    public class Branch : IEntity
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime StartWork { get; set; }
        public DateTime EndWork { get; set; }
        public int CompanyId { get; set; }
        public virtual List<IEmployee> Employees { get; set; }

        public Branch()
        {
            Employees = new List<IEmployee>();
        }
    }
}
