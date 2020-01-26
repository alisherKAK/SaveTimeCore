using SaveTimeCore.AbstractModels.Marker;

namespace SaveTimeCore.DataModels.Dictionary
{
    public class AccountRole : IEntity
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
    }
}
