using CadastroFilmes.Aplication.DTOs;
using CadastroFilmes.Aplication.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CadastroFilmes.UI.Pages.Filme
{
    public class ExcluirFilmeModel : PageModel
    {
        private readonly IFilmeService _filmeService;

        public ExcluirFilmeModel(IFilmeService filmeService)
        {
            _filmeService = filmeService;
        }

        [BindProperty]
        public FilmeDTO FilmeExclusao { get; set; }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            FilmeExclusao = await _filmeService.GetFilmeAsync(id);

            if( FilmeExclusao is null )
                return NotFound();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
           await _filmeService.DeleteFilmeAsync(FilmeExclusao.Id);

            return RedirectToPage(nameof(Index));
        }
    }
}
