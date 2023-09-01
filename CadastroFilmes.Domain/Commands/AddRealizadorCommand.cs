using CadastroFilmes.Domain.Commands.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroFilmes.Domain.Commands
{
    public class AddRealizadorCommand : ICommand
    {
        public AddRealizadorCommand()
        {
            
        }
        public AddRealizadorCommand(int filmeId, int realizadorId)
        {
            FilmeId = filmeId;
            RealizadorId = realizadorId;
        }

        public int FilmeId { get; set; }
        public int RealizadorId { get; set; }
        public void Valid()
        {
        }
    }
}
