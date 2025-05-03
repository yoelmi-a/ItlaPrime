using ItlaPrime.Database.Common;

namespace ItlaPrime.Database.Entities
{
    public class Producer : BaseEntity
    {
        //Navigation Properties
        public ICollection<Series>? Series { get; set; }
    }
}
