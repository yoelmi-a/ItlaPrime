using ItlaPrime.Application.Interfaces;
using ItlaPrime.Application.ViewModels;
using ItlaPrime.Database.Entities;

namespace ItlaPrime.Application.Services
{
    public class SeriesService
    {
        private readonly ISeriesRepository _seriesRepository;

        public SeriesService(ISeriesRepository seriesRepository)
        {
            _seriesRepository = seriesRepository;
        }

        public async Task<List<SeriesViewModel>> GetSeriesAsync()
        {
            return await _seriesRepository.GetAllSeriesViewModelAsync();
        }

        public async Task<List<SeriesViewModel>> GetSeriesByNameAsync(string name)
        {
            return await _seriesRepository.GetAllSeriesViewModelAsync(s => s.Name.Contains(name));
        }

        public async Task<List<SeriesViewModel>> GetSeriesByGenreAsync(int genreId)
        {
            return await _seriesRepository.GetAllSeriesViewModelAsync(s => s.PrimaryGenreID == genreId || s.SecondaryGenreID == genreId);
        }

        public async Task<List<SeriesViewModel>> GetSeriesByProducerAsync(int producerID)
        {
            return await _seriesRepository.GetAllSeriesViewModelAsync(s => s.ProducerID == producerID);
        }

        public async Task CreateSeriesAsync(CreateSeriesViewModel vm)
        {
            Series series =  new Series();
            series.Name = vm.Name;
            series.PrimaryGenreID = vm.PrimaryGenreID;
            series.SecondaryGenreID = vm.SecondaryGenreID;
            series.ProducerID = vm.ProducerID;
            series.ImageUrl = vm.ImageUrl;

            await _seriesRepository.CreateAsync(series);
        }

        public async Task UpdateSeriesAsync(CreateSeriesViewModel vm)
        {
            Series series = new Series();
            series.Id = vm.Id;
            series.Name = vm.Name;
            series.PrimaryGenreID = vm.PrimaryGenreID;
            series.SecondaryGenreID = vm.SecondaryGenreID;
            series.ProducerID = vm.ProducerID;
            series.ImageUrl = vm.ImageUrl;

            await _seriesRepository.UpdateAsync(series);
        }

        public async Task DeleteSeriesAsync(int id)
        {
            Series series = await _seriesRepository.GetByIdAsync(id);
            await _seriesRepository.DeleteAsync(series);
        }
    }
}
