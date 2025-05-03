using ItlaPrime.Database.Common;

namespace ItlaPrime.Database.Entities
{
    public class Series : BaseEntity
    {
        public string ImageUrl { get; set; }
        public int PrimaryGenreID { get; set; }
        public int? SecondaryGenreID { get; set; }
        public int ProducerID { get; set; }

        //Navigation Properties
        public Producer? Producer { get; set; }
        public Genre? PrimaryGenre { get; set; }
        public Genre? SecondaryGenre { get; set; }
    }
}
