using CadastroFilmes.Aplication.DTOs;
using CadastroFilmes.Aplication.IServices;
using CadastroFilmes.Domain.Entities.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CadastroFilmes.UI.Pages.Filme
{
    public class NovoFilmeModel : PageModel
    {
        private readonly IFilmeService _filmeService;

        public NovoFilmeModel(IFilmeService filmeService)
        {
            _filmeService = filmeService;
        }

        [BindProperty]
        public FilmeDTO NovoFilme { get; set; }
        public void OnGet()
        {
            NovoFilme = new FilmeDTO(); 
        }

        public async Task<IActionResult> OnPostAsync() 
        {
            if (!ModelState.IsValid)
                return Page(); 

            await _filmeService.AddFilmeAsync(NovoFilme);

            return RedirectToPage(nameof(Index));
        }

        public IEnumerable<SelectListItem> Categories => Enum.GetValues(typeof(ECategory))
            .Cast<ECategory>().Select(c => new SelectListItem
            {
                Value = c.ToString(),
                Text = c.ToString()
            }); 
    }
}
