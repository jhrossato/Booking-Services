using Domain.ValueObjects;

namespace Domain.Entities
{
    public class Room
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Level { get; set; }
        public bool InMaintenance { get; set; }
        public required Price Price { get; set; } 
        public bool IsAvailable
        {
            get
            {
                if (this.InMaintenance || this.HasGuest)
                {
                    return false;
                };
                return true;
            }
        }
        public bool HasGuest
        {
            //verificar se existem bookings abertos para esta room
            get { return true; }
        }
    }
}