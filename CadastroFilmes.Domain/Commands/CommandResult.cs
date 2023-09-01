using CadastroFilmes.Domain.Commands.Contracts;

namespace CadastroFilmes.Domain.Commands
{
    public class CommandResult : ICommandResult
    {
        public CommandResult() { }

        public CommandResult(object objectResult, bool sucess, string menssage)
        {
            ObjectResult = objectResult;
            Sucess = sucess;
            Menssage = menssage;
        }

        public object ObjectResult { get; set; }
        public bool Sucess { get ; set ; }
        public string Menssage { get; set; }
    }
}
