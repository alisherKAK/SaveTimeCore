using SaveTimeCore.AbstractModels.Marker;
using System;

namespace SaveTimeCore.DataModels.Organization
{
    public class Barber : IEmployee, IAccountOwner
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime WorkDayStart { get; set; }
        public DateTime WorkDayEnd { get; set; }
        public int AccountId { get; set; }
    }
}
