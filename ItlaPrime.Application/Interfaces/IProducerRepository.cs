using ItlaPrime.Database.Entities;

namespace ItlaPrime.Application.Interfaces
{
    public interface IProducerRepository : IBaseRepository<Producer>
    {
        Task<List<Producer>> GetAllAsync();
    }
}
