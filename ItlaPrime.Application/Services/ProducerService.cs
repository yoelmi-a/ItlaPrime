using ItlaPrime.Application.Repositories;
using ItlaPrime.Application.ViewModels;
using ItlaPrime.Database.Entities;

namespace ItlaPrime.Application.Services
{
    public class ProducerService
    {
        private readonly ProducerRepository _producerRepository;

        public ProducerService(ProducerRepository producerRepository)
        {
            _producerRepository = producerRepository;
        }

        public async Task<List<ProducerViewModel>> GetProducersAsync()
        {
            var producers = await _producerRepository.GetAllAsync();
            return producers.Select(g => new ProducerViewModel
            {
                Id = g.Id,
                Name = g.Name
            }).ToList();
        }

        public async Task<ProducerViewModel> GetGenreByIdAsync(int id)
        {
            var producer = await _producerRepository.GetByIdAsync(id);
            return new ProducerViewModel
            {
                Id = producer.Id,
                Name = producer.Name
            };
        }

        public async Task CreateGenreAsync(ProducerViewModel vm)
        {
            Producer producer = new Producer();
            producer.Name = vm.Name;
            await _producerRepository.CreateAsync(producer);
        }

        public async Task UpdateGenreAsync(ProducerViewModel vm)
        {
            Producer producer = new Producer();
            producer.Id = vm.Id;
            producer.Name = vm.Name;
            await _producerRepository.CreateAsync(producer);
        }

        public async Task DeleteGenreAsync(int id)
        {
            var producer = await _producerRepository.GetByIdAsync(id);
            await _producerRepository.DeleteAsync(producer);
        }
    }
}
