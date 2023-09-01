using CadastroFilmes.Aplication.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CadastroFilmes.UI.Pages.Filme
{
    public class AssociarRealizadorModel : PageModel
    {
        private readonly IFilmeService _filmeService;
        private readonly IRealizadorService _realizadorService;

        public AssociarRealizadorModel(IFilmeService filmeService, IRealizadorService realizadorService)
        {
            _filmeService = filmeService;
            _realizadorService = realizadorService;
        }
        [BindProperty]
        public int FilmeId { get; set; }

        [BindProperty]
        public int RealizadorId { get; set; }

        public SelectList FilmeSelect { get; set; }
        public SelectList RealizadoresSelect { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            FilmeSelect = new SelectList(await _filmeService.GetFilmesAsync(), "Id", "Title");
            RealizadoresSelect = new SelectList(await _realizadorService.GetRealizadores(), "Id", "Name");

            if (FilmeSelect is null || RealizadoresSelect is null)
                return NotFound();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if(!ModelState.IsValid)
                return Page();
            await _filmeService.FilmeRealizadorAsync(FilmeId, RealizadorId);

            return RedirectToPage(nameof(Index)); 
        }
    }
}
