using CadastroFilmes.Domain.Commands;
using CadastroFilmes.Domain.Commands.Contracts;
using CadastroFilmes.Domain.Entities;
using CadastroFilmes.Domain.Handlers.Contracts;
using CadastroFilmes.Domain.IRepositories;

namespace CadastroFilmes.Domain.Handlers
{
    public class CommandFilmeHandler : ICommandHandler<InserirFilmeCommand>, 
                                       ICommandHandler<UpdateFilmeCommand>, 
                                       ICommandHandler<DeleteFilmeCommand>, 
                                       ICommandHandler<AddRealizadorCommand>
    {
        private readonly IUniteOfWork _uniteOfWork;

        public CommandFilmeHandler(IUniteOfWork uniteOfWork)
        {
            _uniteOfWork = uniteOfWork;
        }

        public async Task<ICommandResult> Handle(InserirFilmeCommand command)
        {
            //validar o comando
            command.Valid(); 

            if(!command.IsValid)
                return new CommandResult(command.Notifications, false, "Não foi possivel inserir o filme");

            //Cria objecto filme
            var filme = new Filme(command.Title, 
                        command.ReleaseYear,
                        command.DurationsInMinute, 
                        command.Category);

            //Salva o Fime no banco de dados
            await _uniteOfWork.FilmeRepository.AddFilme(filme);
            await _uniteOfWork.CommitAsync(); 

            //Retorna o objecto salvo
            return new CommandResult(filme, true, "Filme Inserido com sucesso"); 
        }

        public async Task<ICommandResult> Handle(UpdateFilmeCommand command)
        {
            //Validar o Commando
            command.Valid();

            if (!command.IsValid)
                return new CommandResult(command.Notifications, false, "não foi possivel actualizar o filme");

            //pegar o Objecto que será actualizado; 
            var filme = await _uniteOfWork.FilmeRepository.GetFilmeByIdAsync(command.Id);
            
            //Actualiza o objecto pego do Banco de dados
            filme.UpdateFilme(command.Title, 
                command.ReleaseYear, 
                command.DurationsInMinute, 
                command.Category);

            //Salvar as alterações o banco de dados

             _uniteOfWork.FilmeRepository.UpdateFilme(filme);
            await _uniteOfWork.CommitAsync();

            return new CommandResult(filme, true, "Filme actualizado com Sucesso"); 
        }

        public async Task<ICommandResult> Handle(DeleteFilmeCommand command)
        {
            //pegar o filme do banco de dados
            var filme = await _uniteOfWork.FilmeRepository.GetFilmeByIdAsync(command.Id);

            //validar se o filme Existe

            if (filme is null)
                return new CommandResult(null, false, "O filme não existe no banco de dados");

            //Remover o filme do banco de dados 
            _uniteOfWork.FilmeRepository.DeleteFilme(filme);

            //Salvar a alteração
            await _uniteOfWork.CommitAsync();

            //Retorna o resultado

            return new CommandResult(filme, true, "Filme removido com sucesso"); 
        }

        public async Task<ICommandResult> Handle(AddRealizadorCommand command)
        {
            //pegar o Filme e o realizador 
            var filme = await _uniteOfWork.FilmeRepository.GetFilmeByIdAsync(command.FilmeId);
            var realizador = await _uniteOfWork.RealizadorRepository.GetRealizadorByIdAsync(command.RealizadorId);

            //Validar o Filme 
            if (filme is null||realizador is null)
                return new CommandResult(null, false, "Filme ou realizador Inexistente no banco de dados"); 


            //Associar ao filme 
            filme.AddRealizador(realizador);

            // Actualizar a base de dados
            _uniteOfWork.FilmeRepository.UpdateFilme(filme);
            _uniteOfWork.RealizadorRepository.UpdateRealizador(realizador);
            await _uniteOfWork.CommitAsync();

            //Retornar o  filme actualizado
            return new CommandResult(filme, true, "Filme e realizador associado com sucesso"); 
        }
    }
}