using CadastroFilmes.Domain.Commands.Contracts;

namespace CadastroFilmes.Domain.Commands
{
    public class DeleteFilmeCommand : ICommand
    {
        public int Id { get; set; }
        public void Valid()
        {
            
        }
    }
}
