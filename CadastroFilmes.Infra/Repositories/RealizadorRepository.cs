using CadastroFilmes.Domain.Entities;
using CadastroFilmes.Domain.IRepositories;
using CadastroFilmes.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace CadastroFilmes.Infra.Repositories
{
    public class RealizadorRepository : BaseRepository<Realizador>,IRealizadorRepository
    {
        private readonly CadastroFilmesDbContext _context;

        public RealizadorRepository(CadastroFilmesDbContext context)
            :base(context)
        {
            _context = context;
        }

        public async Task<Realizador> GetRealizadorByFilmesAsync(int id)
        {
            return await _context.Realizadores
                    .Include(x => x.Filmes)
                    .FirstOrDefaultAsync(x => x.Id == id); 
        }
    }
}
