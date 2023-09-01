using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CadastroFilmes.Aplication.DTOs
{
    public  class RealizadorDTO
    {
        public int Id { get; set; }
        [DisplayName("Nome")]
        [Required(ErrorMessage ="Campo Obrigatorio")]
        [MinLength(6, ErrorMessage ="Tamanho Insuficiente")]
        public string Name { get; set; }

        [Range (18, 200, ErrorMessage ="A idade do realizador deve ser superior a 18")]
        public int Age { get; set; }
    }
}
