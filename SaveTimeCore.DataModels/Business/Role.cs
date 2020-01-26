using SaveTimeCore.AbstractModels.Marker;

namespace SaveTimeCore.DataModels.Business
{
    public class Role : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
