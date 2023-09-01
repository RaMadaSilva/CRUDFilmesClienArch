using CadastroFilmes.Aplication.DTOs;
using CadastroFilmes.Aplication.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CadastroFilmes.UI.Pages.Realizador
{
    public class ExcluirRealizadorModel : PageModel
    {
        private readonly IRealizadorService _realizadorService;

        public ExcluirRealizadorModel(IRealizadorService realizadorService)
        {
            _realizadorService = realizadorService;
        }

        [BindProperty]
        public RealizadorDTO ExcluirRealizador { get; set; }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            ExcluirRealizador = await _realizadorService.GetRealizadorById(id);

            if (ExcluirRealizador == null)
                return NotFound(); 
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {

            await _realizadorService.DeleteRealizador(ExcluirRealizador.Id);

            return RedirectToPage(nameof(Index)); 
        }
    }
}
