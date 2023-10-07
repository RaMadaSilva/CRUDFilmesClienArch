using CadastroFilmes.Domain.Commands;
using CadastroFilmes.Domain.Commands.Contracts;
using CadastroFilmes.Domain.Entities;
using CadastroFilmes.Domain.Handlers.Contracts;
using CadastroFilmes.Domain.IRepositories;

namespace CadastroFilmes.Domain.Handlers
{
    public class CommandRealizadorHandler : ICommandHandler<InsertRealizadorCommand>, 
                ICommandHandler<UpdateRealizadorCommand>, 
                ICommandHandler<DeleteRealizadorCommand>
    {
        private readonly IUniteOfWork _uniteOfWork;

        public CommandRealizadorHandler(IUniteOfWork uniteOfWork)
        {
            _uniteOfWork = uniteOfWork;
        }

        public async Task<ICommandResult> Handle(InsertRealizadorCommand command)
        {
            command.Valid();

            if (!command.IsValid)
                return new CommandResult(command.Notifications, false, "Não foi possivel inserir");

            var realizador = new Realizador(command.Name, command.Age);

            await _uniteOfWork.RealizadorRepository.AddAsync(realizador);
            await _uniteOfWork.CommitAsync();

            return new CommandResult(realizador, true, "realizador criado com sucesso"); 
        }

        public async Task<ICommandResult> Handle(UpdateRealizadorCommand command)
        {
            command.Valid();

            if (!command.IsValid)
                return new CommandResult(command.Notifications, false, "Não foi possivel actualizar");
            
            var realizador = await _uniteOfWork.RealizadorRepository.GetByIdAsync(command.Id);

            if (realizador is null)
                return new CommandResult(null, false, "O realizador não existe na base de dados");

            realizador.UpdateRealizador(command.Name, command.Age); 

             _uniteOfWork.RealizadorRepository.UpdateAsync(realizador);
            await _uniteOfWork.CommitAsync();

            return new CommandResult(realizador, true, "realizador Actualizado com sucesso"); 
        }

        public async Task<ICommandResult> Handle(DeleteRealizadorCommand command)
        {
            var realizador = await _uniteOfWork.RealizadorRepository.GetByIdAsync(command.Id);

            if (realizador is null)
                return new CommandResult(null, false, "Este realizador Não existe");

            _uniteOfWork.RealizadorRepository.DeleteAsync(realizador.Id); 
            await _uniteOfWork.CommitAsync();

            return new CommandResult(realizador, true, "realizador removido com sucesso"); 
        }
    }
}
