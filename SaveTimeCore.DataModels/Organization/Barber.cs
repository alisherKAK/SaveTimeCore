using SaveTimeCore.AbstractModels.Marker;
using SaveTimeCore.DataModels.Dictionary;
using System;
using System.Collections.Generic;

namespace SaveTimeCore.DataModels.Organization
{
    public class Barber : IEmployee, IAccountOwner
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime WorkDayStart { get; set; }
        public DateTime WorkDayEnd { get; set; }
        public virtual List<Service> Services { get; set; }
        public int BranchId { get; set; }
        public int AccountId { get; set; }

        public Barber()
        {
            Services = new List<Service>();
        }
    }
}
