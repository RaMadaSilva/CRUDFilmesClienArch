using CadastroFilmes.Aplication.DTOs;
using CadastroFilmes.Aplication.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CadastroFilmes.UI.Pages.Realizador
{
    public class IndexModel : PageModel
    {
        private readonly IRealizadorService _realizadorService;

        public IndexModel(IRealizadorService realizadorService)
        {
            _realizadorService = realizadorService;
        }
        [BindProperty]
        public IEnumerable<RealizadorDTO> Realizadores { get; set; }
        public async Task OnGetAsync()
        {
            Realizadores = await _realizadorService.GetRealizadores();  
        }
    }
}
