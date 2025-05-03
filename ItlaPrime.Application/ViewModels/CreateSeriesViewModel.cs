namespace ItlaPrime.Application.ViewModels
{
    public class CreateSeriesViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public int PrimaryGenreID { get; set; }
        public int? SecondaryGenreID { get; set; }
        public int ProducerID { get; set; }
    }
}
