using CadastroFilmes.Domain.Entities;

namespace CadastroFilmes.Domain.IRepositories
{
    public interface IRealizadorRepository: IBaseRepository<Realizador>
    {
        Task<Realizador> GetRealizadorByFilmesAsync(int id);
    }
}