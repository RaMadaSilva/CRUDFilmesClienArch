using CadastroFilmes.Aplication.DTOs;

namespace CadastroFilmes.Aplication.IServices
{
    public interface IRealizadorService
    {
        Task<IEnumerable<RealizadorDTO>> GetRealizadores();
        Task<RealizadorDTO> GetRealizadorById(int id);
        Task<RealizadorDTO> GetRealizadoWithFilme(int id);

        Task UpdateRealizador(RealizadorDTO realizadorDTO);
        Task AddRealizador(RealizadorDTO realizadorDTO);
        Task DeleteRealizador(int id);
        List<string> ObterListaNomes(List<RealizadorDTO> realizadorsDto); 
    }
}
