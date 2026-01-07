using Orders.Backend.Repositories.Implementations;
using Orders.Backend.Repository.Interfaces;
using Orders.Backend.UnitsOfWork.Interfaces;

namespace Orders.Backend.UnitsOfWork.Implementations;

public class GenericUnitOfWork<T> : IGenericUnitOfWork<T> where T : class
{
    private readonly IGenericRepository<T> _repository;

    public GenericUnitOfWork(IGenericRepository<T> repository )
    {
        _repository = repository;
    }
    public virtual async Task<Shared.Entities.Responses.ActionResponse<T>> AddAsync(T entity) => await
        _repository.AddAsync(entity);

    public virtual async Task<Shared.Entities.Responses.ActionResponse<T>> DeleteAsync(int id) => await
        _repository.DeleteAsync(id);

    public virtual async Task<Shared.Entities.Responses.ActionResponse<T>> GetAsync(int id) => await
        _repository.GetAsync(id);

    public virtual async Task<Shared.Entities.Responses.ActionResponse<IEnumerable<T>>> GetAsync() => await
        _repository.GetAsync();

    public virtual async Task<Shared.Entities.Responses.ActionResponse<T>> UpdateAsync(T entity) => await
        _repository.UpdateAsync(entity);
}
