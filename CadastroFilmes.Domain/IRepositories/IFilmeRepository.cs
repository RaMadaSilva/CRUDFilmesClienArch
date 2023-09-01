using CadastroFilmes.Domain.Entities;

namespace CadastroFilmes.Domain.IRepositories
{
    public interface IFilmeRepository
    {
        Task<IEnumerable<Filme>> GetFilmesAsync();
        Task<Filme> GetFilmeByIdAsync(int id);
        Task<IEnumerable<Filme>> GetFilmesWithRealizadoresAsync();
        Task AddFilme(Filme filme);
        void UpdateFilme(Filme filme);
        void DeleteFilme(Filme filme); 
    }
}