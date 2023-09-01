using CadastroFilmes.Aplication.DTOs;
using CadastroFilmes.Aplication.IServices;
using CadastroFilmes.Domain.Entities.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CadastroFilmes.UI.Pages.Filme
{
    public class EditarFilmeModel : PageModel
    {
        private readonly IFilmeService _filmeService;

        public EditarFilmeModel(IFilmeService filmeService)
        {
            _filmeService = filmeService;
        }

        [BindProperty]
        public FilmeDTO EditFilme { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            EditFilme = await _filmeService.GetFilmeAsync(id); 

            if(EditFilme is null) 
                return NotFound();
            return Page(); 
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page(); 
            await _filmeService.UpdateFilmeAsync(EditFilme);

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
