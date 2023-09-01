using CadastroFilmes.Domain.Entities;
using CadastroFilmes.Domain.IRepositories;
using CadastroFilmes.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace CadastroFilmes.Infra.Repositories
{
    public class RealizadorRepository : IRealizadorRepository
    {
        private readonly CadastroFilmesDbContext _context;

        public RealizadorRepository(CadastroFilmesDbContext context)
        {
            _context = context;
        }

        public async Task AddRealizador(Realizador realizador)
        {
            await _context.Realizadores.AddAsync(realizador);
        }

        public void DeleteRealizador(Realizador realizador)
        {
            _context.Realizadores.Remove(realizador);
        }

        public async Task<IEnumerable<Realizador>> GetRealizadoresAsync()
        {
            return await _context.Realizadores.AsNoTracking().ToListAsync();
        }

        public async Task<Realizador> GetRealizadorByFilmesAsync(int id)
        {
            return await _context.Realizadores
                    .Include(x => x.Filmes)
                    .FirstOrDefaultAsync(x => x.Id == id); 
        }

        public async Task<Realizador> GetRealizadorByIdAsync(int id)
        {
            return await _context.Realizadores.FirstOrDefaultAsync(x => x.Id == id); 
        }

        public void UpdateRealizador(Realizador realizador)
        {
            _context.Realizadores.Update(realizador);

        }
    }
}
