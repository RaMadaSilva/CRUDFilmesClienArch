using CadastroFilmes.Aplication.DTOs;
using CadastroFilmes.Domain.Commands;

namespace CadastroFilmes.Aplication.IServices
{
    public interface IRealizadorService
    {
        Task<IEnumerable<RealizadorDTO>> GetRealizadores();
        Task<RealizadorDTO> GetRealizadorById(int id);
        Task<RealizadorDTO> GetRealizadoWithFilme(int id);

        Task UpdateRealizador(RealizadorDTO realizadorDto);
        Task AddRealizador(InsertRealizadorCommand command);
        Task DeleteRealizador(int id);
        List<string> ObterListaNomes(List<RealizadorDTO> realizadorsDto); 
    }
}
