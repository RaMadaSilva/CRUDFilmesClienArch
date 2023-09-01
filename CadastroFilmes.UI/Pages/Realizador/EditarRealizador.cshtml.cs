using CadastroFilmes.Aplication.DTOs;
using CadastroFilmes.Aplication.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CadastroFilmes.UI.Pages.Realizador
{
    public class EditarRealizadorModel : PageModel
    {
        private readonly IRealizadorService _realizadorService;

        public EditarRealizadorModel(IRealizadorService realizadorService)
        {
            _realizadorService = realizadorService;
        }
        [BindProperty]
        public RealizadorDTO EditarRealizador { get; set; }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            EditarRealizador = await _realizadorService.GetRealizadorById(id); 
            if (EditarRealizador is null)
                return NotFound();
            return Page(); 
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if(!ModelState.IsValid)
                return BadRequest();
            await _realizadorService.UpdateRealizador(EditarRealizador);

            return RedirectToPage(nameof(Index)); 
        }
    }
}
