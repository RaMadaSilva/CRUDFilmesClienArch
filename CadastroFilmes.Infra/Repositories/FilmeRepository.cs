using CadastroFilmes.Domain.IRepositories;
using CadastroFilmes.Domain.Entities;
using CadastroFilmes.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace CadastroFilmes.Infra.Repositories
{
    public class FilmeRepository : IFilmeRepository
    {
        private readonly CadastroFilmesDbContext _context;

        public FilmeRepository(CadastroFilmesDbContext context)
        {
            _context = context;
        }

        public async Task AddFilme(Filme filme)
        {
            await _context.AddAsync(filme);
        }

        public void DeleteFilme(Filme filme)
        {
            _context.Filmes.Remove(filme);
        }

        public async Task<Filme> GetFilmeByIdAsync(int id)
        {
            return await _context.Filmes.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Filme>> GetFilmesAsync()
        {
            return await _context.Filmes.AsNoTracking().ToListAsync(); 
        }

        public async Task<IEnumerable<Filme>> GetFilmesWithRealizadoresAsync()
        {
            return await _context.Filmes.Include(x => x.Realizadors).ToListAsync(); 
        }

        public void UpdateFilme(Filme filme) { 
       
            _context.Filmes.Update(filme);
        }
    }
}
