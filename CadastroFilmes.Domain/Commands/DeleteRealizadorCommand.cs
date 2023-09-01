using CadastroFilmes.Domain.Commands.Contracts;

namespace CadastroFilmes.Domain.Commands
{
    public class DeleteRealizadorCommand : ICommand
    {
        public DeleteRealizadorCommand()
        {
            
        }
        public DeleteRealizadorCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
        public void Valid()
        {
            
        }
    }
}
