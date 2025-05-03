using System.Linq;
using System.Linq.Expressions;
using ItlaPrime.Application.Interfaces;
using ItlaPrime.Database.Context;
using ItlaPrime.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace ItlaPrime.Application.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        private readonly ItlaPrimeContext _context;

        public GenreRepository(ItlaPrimeContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Genre entity)
        {
            await _context.Genres.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Genre entity)
        {
            _context.Genres.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Genre>> GetAllAsync()
        {
            return await _context.Genres.ToListAsync();
        }

        public async Task<Genre> GetByIdAsync(int id)
        {
            return await _context.Genres.FindAsync(id);
        }

        public async Task UpdateAsync(Genre entity)
        {
            _context.Genres.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
