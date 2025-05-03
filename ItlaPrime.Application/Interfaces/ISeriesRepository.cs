using System.Linq.Expressions;
using ItlaPrime.Application.ViewModels;
using ItlaPrime.Database.Entities;

namespace ItlaPrime.Application.Interfaces
{
    public interface ISeriesRepository : IBaseRepository<Series>
    {
        Task<List<SeriesViewModel>> GetAllSeriesViewModelAsync();
        Task<List<SeriesViewModel>> GetAllSeriesViewModelAsync(Expression<Func<Series, bool>> filter);
    }
}
