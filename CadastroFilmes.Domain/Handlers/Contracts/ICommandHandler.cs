using CadastroFilmes.Domain.Commands.Contracts;

namespace CadastroFilmes.Domain.Handlers.Contracts
{
    public interface ICommandHandler<T> where T: ICommand
    {
        public Task<ICommandResult> Handle(T command); 
    }
}
