using CadastroFilmes.Aplication.DTOs;
using CadastroFilmes.Aplication.IServices;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CadastroFilmes.UI.Pages.Filme
{
    public class IndexModel : PageModel
    {
        private readonly IFilmeService _filmeService;

        public IndexModel(IFilmeService filmeService)
        {
            _filmeService = filmeService;
        }
        public IEnumerable<FilmeDTO> Filmes { get; set; }
        public async Task OnGetAsync()
        {
            Filmes = await _filmeService.GetFilmesAsync(); 
        }
    }
}
