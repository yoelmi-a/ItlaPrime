using ItlaPrime.Application.Services;
using ItlaPrime.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ItlaPrime.MVC.Controllers
{
    public class SeriesController : Controller
    {
        private readonly SeriesService _seriesService;
        private readonly ProducerService _producerService;
        private readonly GenreService _genreService;

        public SeriesController(SeriesService seriesService, ProducerService producerService, GenreService genreService)
        {
            _seriesService = seriesService;
            _producerService = producerService;
            _genreService = genreService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Create()
        {
            var genres = await _genreService.GetGenresAsync();
            var genresOptions = genres.Select(g => new SelectListItem
            {
                Value = g.Id.ToString(),
                Text = g.Name
            }).ToList();

            var producers = await _producerService.GetProducersAsync();
            var producersOptions = producers.Select(g => new SelectListItem
            {
                Value = g.Id.ToString(),
                Text = g.Name
            }).ToList();
            ViewBag.Genres = new SelectList(genres, "Id", "Name");
            ViewBag.Producers = new SelectList(producersOptions, "Value", "Text");
            return View(new CreateSeriesViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateSeriesViewModel vm)
        {
            await _seriesService.CreateSeriesAsync(vm);
            return RedirectToRoute(new { controller = "Series", action = "Index" });
        }

        public async Task<IActionResult> Edit(int id)
        {
            return View("Create", await _seriesService.GetSeriesById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CreateSeriesViewModel vm)
        {
            await _seriesService.UpdateSeriesAsync(vm);
            return RedirectToRoute(new { controller = "Series", action = "Index" });
        }
    }
}
