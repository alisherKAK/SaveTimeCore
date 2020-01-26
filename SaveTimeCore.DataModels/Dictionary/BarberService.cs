using SaveTimeCore.AbstractModels.Marker;

namespace SaveTimeCore.DataModels.Dictionary
{
    public class BarberService : IEntity
    {
        public int Id { get; set; }
        public int BarberId { get; set; }
        public int ServiceId { get; set; }
    }
}
