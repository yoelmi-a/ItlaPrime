using ItlaPrime.Application.Repositories;
using ItlaPrime.Application.ViewModels;
using ItlaPrime.Database.Entities;

namespace ItlaPrime.Application.Services
{
    public class GenreService
    {
        private readonly GenreRepository _genreRepository;

        public GenreService(GenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }

        public async Task<List<GenreViewModel>> GetGenresAsync()
        {
            var genres = await _genreRepository.GetAllAsync();
            return genres.Select(g => new GenreViewModel
            {
                Id = g.Id,
                Name = g.Name
            }).ToList();
        }

        public async Task<GenreViewModel> GetGenreByIdAsync(int id)
        {
            var genre = await _genreRepository.GetByIdAsync(id);
            return new GenreViewModel
            {
                Id = genre.Id,
                Name = genre.Name
            };
        }

        public async Task CreateGenreAsync(GenreViewModel vm)
        {
            Genre genre = new Genre();
            genre.Name = vm.Name;
            await _genreRepository.CreateAsync(genre);
        }

        public async Task UpdateGenreAsync(GenreViewModel vm)
        {
            Genre genre = new Genre();
            genre.Id = vm.Id;
            genre.Name = vm.Name;
            await _genreRepository.UpdateAsync(genre);
        }

        public async Task DeleteGenreAsync(int id)
        {
            var genre = await _genreRepository.GetByIdAsync(id);
            await _genreRepository.DeleteAsync(genre);
        }
    }
}
