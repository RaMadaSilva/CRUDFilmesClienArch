using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroFilmes.Domain.Commands.Contracts
{
    public interface ICommandResult
    {
        public Object ObjectResult { get; set; }
        public bool Sucess { get; set; }
        public string Menssage { get; set; }
    }
}
