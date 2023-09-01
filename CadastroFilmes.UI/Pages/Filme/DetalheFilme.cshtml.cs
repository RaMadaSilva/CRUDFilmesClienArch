using CadastroFilmes.Aplication.DTOs;
using CadastroFilmes.Aplication.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CadastroFilmes.UI.Pages.Filme
{
    public class DetalheFilmeModel : PageModel
    {
        private readonly IFilmeService _filmeService;
        private readonly IRealizadorService _realizadorService;

        public DetalheFilmeModel(IFilmeService filmeService, 
            IRealizadorService realizadorService)
        {
            _filmeService = filmeService;
            _realizadorService = realizadorService;
        }

        [BindProperty]
        public FilmeDTO DetalheFilme { get; set; }
        [BindProperty]
        public List<string> NomesRealizadores { get; set; }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            DetalheFilme = await _filmeService.GetFilmesWithRealizadorAsync(id);
            NomesRealizadores = _realizadorService.ObterListaNomes(DetalheFilme.Realizadores); 



            if (DetalheFilme is null)
                return NotFound();

            return Page(); 
        }
    }
}
