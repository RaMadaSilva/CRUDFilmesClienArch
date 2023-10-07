using CadastroFilmes.Domain.Entities;

namespace CadastroFilmes.Domain.IRepositories
{
    public interface IFilmeRepository: IBaseRepository<Filme>
    {
        Task<IEnumerable<Filme>> GetFilmesWithRealizadoresAsync();
    }
}