using SaveTimeCore.AbstractModels.Marker;

namespace SaveTimeCore.DataModels.Business
{
    public class Client : IEntity, IAccountOwner
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AccountId { get; set; }
    }
}
