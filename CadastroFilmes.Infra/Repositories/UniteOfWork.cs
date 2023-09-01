using CadastroFilmes.Domain.IRepositories;
using CadastroFilmes.Infra.Context;

namespace CadastroFilmes.Infra.Repositories
{
    public class UniteOfWork : IUniteOfWork
    {
        private IFilmeRepository _filmeRepository;
        private IRealizadorRepository _realizadorRepository;

        private readonly CadastroFilmesDbContext _context;

        public UniteOfWork(CadastroFilmesDbContext context)
        {
            _context = context;
        }

        public IFilmeRepository FilmeRepository 
            { get => _filmeRepository ?? new FilmeRepository(_context);  }

        public IRealizadorRepository RealizadorRepository 
            { get => _realizadorRepository ?? new RealizadorRepository(_context);}

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync(); 
        }
    }
}