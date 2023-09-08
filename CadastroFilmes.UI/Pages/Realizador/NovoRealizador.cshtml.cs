using CadastroFilmes.Aplication.DTOs;
using CadastroFilmes.Aplication.IServices;
using CadastroFilmes.Domain.Commands;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CadastroFilmes.UI.Pages.Realizador
{
    public class NovoRealizadorModel : PageModel
    {
        private readonly IRealizadorService _realizadorService;

        public NovoRealizadorModel(IRealizadorService realizadorService)
        {
            _realizadorService = realizadorService;
        }

        [BindProperty]
        public InsertRealizadorCommand Realizador { get; set; }

        public void OnGet()
        {
            Realizador = new InsertRealizadorCommand(); 
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page(); 
           await _realizadorService.AddRealizador(Realizador);
            return RedirectToPage(nameof(Index)); 
        }
    }
}
