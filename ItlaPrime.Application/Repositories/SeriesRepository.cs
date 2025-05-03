using System.Linq.Expressions;
using ItlaPrime.Application.Interfaces;
using ItlaPrime.Application.ViewModels;
using ItlaPrime.Database.Context;
using ItlaPrime.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace ItlaPrime.Application.Repositories
{
    public class SeriesRepository : ISeriesRepository
    {
        private readonly ItlaPrimeContext _context;

        public SeriesRepository(ItlaPrimeContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Series entity)
        {
            await _context.Series.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Series entity)
        {
            _context.Series.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<SeriesViewModel>> GetAllSeriesViewModelAsync()
        {
            return await _context.Series.Select(s => new SeriesViewModel
            {
                Id = s.Id,
                Name = s.Name,
                ImageUrl = s.ImageUrl,
                PrimaryGenre = s.PrimaryGenre!.Name,
                SecondaryGenre = s.SecondaryGenre!.Name,
                Producer = s.Producer!.Name,
            }).ToListAsync();
        }

        public async Task<List<SeriesViewModel>> GetAllSeriesViewModelAsync(Expression<Func<Series, bool>> filter)
        {
            return await _context.Series.Where(filter).Select(s => new SeriesViewModel
            {
                Id = s.Id,
                Name = s.Name,
                ImageUrl = s.ImageUrl,
                PrimaryGenre = s.PrimaryGenre!.Name,
                SecondaryGenre = s.SecondaryGenre!.Name,
                Producer = s.Producer!.Name,
            }).ToListAsync();
        }

        public async Task<Series> GetByIdAsync(int id)
        {
            return await _context.Series.FindAsync(id);
        }

        public async Task UpdateAsync(Series entity)
        {
            _context.Series.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
