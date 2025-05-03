using ItlaPrime.Database.Entities;

namespace ItlaPrime.Application.Interfaces
{
    public interface IGenreRepository : IBaseRepository<Genre>
    {
        Task<List<Genre>> GetAllAsync();
    }
}
