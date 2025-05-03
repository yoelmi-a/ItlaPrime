namespace ItlaPrime.Application.ViewModels
{
    public class SeriesViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string PrimaryGenre { get; set; }
        public string? SecondaryGenre { get; set; }
        public string Producer { get; set; }
    }
}
