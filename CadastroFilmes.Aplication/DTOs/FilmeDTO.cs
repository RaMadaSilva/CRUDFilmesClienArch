using CadastroFilmes.Domain.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace CadastroFilmes.Aplication.DTOs
{
    public  class FilmeDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo Obrigatorio")]
        public string Title { get;  set; }

        [Required(ErrorMessage = "Campo Obrigatorio")]
        public int ReleaseYear { get;  set; }
        [Required(ErrorMessage = "Campo Obrigatorio")]
        public int DurationsInMinute { get;  set; }

        [Required(ErrorMessage = "Campo Obrigatorio")]
        public ECategory Category { get;  set; }

        public List<RealizadorDTO> Realizadores { get; set; }


    }
}
