using CadastroFilmes.Domain.Entities;
using CadastroFilmes.Domain.IRepositories;
using CadastroFilmes.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace CadastroFilmes.Infra.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : Entity
    {
        private readonly CadastroFilmesDbContext _context;
        private readonly DbSet<TEntity> _set; 

        public BaseRepository(CadastroFilmesDbContext context)
        {
            _context = context;
           _set = _context.Set<TEntity>(); 
        }

        public async Task AddAsync(TEntity entity)
        {
           await _context.AddAsync(entity);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
           await  Task.CompletedTask;
           return  _set.AsNoTracking().ToList();
        }

        public async Task<TEntity> GetByIdAsync(int id) 
            => await _set.FindAsync(id);
        

        public async Task UpdateAsync(TEntity entity)
        {
            await Task.CompletedTask; 
            _set.Entry(entity).State = EntityState.Modified;
        }
        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id); 
            _set.Remove(entity);
        }
    }
}
