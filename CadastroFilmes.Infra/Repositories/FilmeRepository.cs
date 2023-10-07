using CadastroFilmes.Domain.IRepositories;
using CadastroFilmes.Domain.Entities;
using CadastroFilmes.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace CadastroFilmes.Infra.Repositories
{
    public class FilmeRepository :BaseRepository<Filme>, IFilmeRepository
    {
        private readonly CadastroFilmesDbContext _context;

        public FilmeRepository(CadastroFilmesDbContext context)
            :base(context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Filme>> GetFilmesWithRealizadoresAsync()
        {
            return await _context.Filmes.Include(x => x.Realizadors).ToListAsync(); 
        }
    }
}
