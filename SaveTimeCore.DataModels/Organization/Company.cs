using SaveTimeCore.AbstractModels.Marker;
using System.Collections.Generic;

namespace SaveTimeCore.DataModels.Organization
{
    public class Company : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public virtual List<Branch> Branches { get; set; }

        public Company()
        {
            Branches = new List<Branch>();
        }
    }
}
