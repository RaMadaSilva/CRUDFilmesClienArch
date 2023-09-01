using CadastroFilmes.Aplication.DTOs;

namespace CadastroFilmes.Aplication.IServices
{
    public interface IFilmeService
    {
        Task<IEnumerable<FilmeDTO>> GetFilmesAsync();
        Task<FilmeDTO> GetFilmeAsync(int id);
        Task<FilmeDTO> GetFilmesWithRealizadorAsync(int id);

        Task UpdateFilmeAsync(FilmeDTO realizadorDTO);
        Task AddFilmeAsync(FilmeDTO realizadorDTO);
        Task DeleteFilmeAsync(int id);

        Task FilmeRealizadorAsync (int filmeId, int realizadorId);
    }
}
