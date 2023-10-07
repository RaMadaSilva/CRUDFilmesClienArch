using CadastroFilmes.Domain.Entities;

namespace CadastroFilmes.Domain.IRepositories
{
    public interface IBaseRepository<TEntity> where TEntity : Entity
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(int id);
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity); 
        Task DeleteAsync(int id);
    }
}
