using System.Linq;
using System.Linq.Expressions;
using ItlaPrime.Application.Interfaces;
using ItlaPrime.Database.Context;
using ItlaPrime.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace ItlaPrime.Application.Repositories
{
    public class ProducerRepository : IProducerRepository
    {
        private readonly ItlaPrimeContext _context;

        public ProducerRepository(ItlaPrimeContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Producer entity)
        {
            await _context.Producers.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Producer entity)
        {
            _context.Producers.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Producer>> GetAllAsync()
        {
            return await _context.Producers.ToListAsync();
        }

        public async Task<Producer> GetByIdAsync(int id)
        {
            return await _context.Producers.FindAsync(id);
        }

        public async Task UpdateAsync(Producer entity)
        {
            _context.Producers.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
