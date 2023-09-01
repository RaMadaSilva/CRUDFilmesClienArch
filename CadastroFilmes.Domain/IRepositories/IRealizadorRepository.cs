using CadastroFilmes.Domain.Entities;

namespace CadastroFilmes.Domain.IRepositories
{
    public interface IRealizadorRepository
    {
        Task<IEnumerable<Realizador>> GetRealizadoresAsync();
        Task<Realizador> GetRealizadorByIdAsync(int id);
        Task<Realizador> GetRealizadorByFilmesAsync(int id);
        Task AddRealizador(Realizador realizador);
        void UpdateRealizador(Realizador realizador);
        void DeleteRealizador(Realizador realizador);
    }
}