using CadastroFilmes.Aplication.DTOs;
using CadastroFilmes.Aplication.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CadastroFilmes.UI.Pages.Realizador
{
    public class DetalheRealizadorModel : PageModel
    {
        private readonly IRealizadorService _realizadorService;

        public DetalheRealizadorModel(IRealizadorService realizadorService)
        {
            _realizadorService = realizadorService;
        }
        [BindProperty]
        public RealizadorDTO DetalheRealizador { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            DetalheRealizador = await _realizadorService.GetRealizadorById(id);
            if (DetalheRealizador is null)
                return NotFound();
            return Page();
        }
    }
}
