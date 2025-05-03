using ItlaPrime.Database.Common;

namespace ItlaPrime.Database.Entities
{
    public class Genre : BaseEntity
    {
        //Navigation Properties
        public ICollection<Series>? PrimarySeries { get; set; }
        public ICollection<Series>? SecondarySeries { get; set; }

    }
}
