using SaveTimeCore.AbstractModels.Marker;

namespace SaveTimeCore.DataModels.Organization
{
    public class SystemAdmin : IEmployee, IAccountOwner
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AccountId { get; set; }
    }
}
