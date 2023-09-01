using AutoMapper;
using CadastroFilmes.Aplication.DTOs;
using CadastroFilmes.Aplication.IServices;
using CadastroFilmes.Domain.Commands;
using CadastroFilmes.Domain.Handlers;

namespace CadastroFilmes.Aplication.Services
{
    public class FilmeService : IFilmeService
    {
        private readonly CommandFilmeHandler _handler;
        private readonly QueryFilmeHandler _query; 
        private readonly IMapper _mapper;

        public FilmeService(CommandFilmeHandler handler, QueryFilmeHandler query, IMapper mapper)
        {
            _handler = handler;
            _mapper = mapper;
            _query = query;
        }

        public async Task AddFilmeAsync(FilmeDTO filmeDTO)
        {
            var filmeCommand = _mapper.Map<InserirFilmeCommand>(filmeDTO);
            await _handler.Handle(filmeCommand); 
        }

        public async Task DeleteFilmeAsync(int id)
        {
            var deleteCommand = new DeleteFilmeCommand { Id = id };
            await _handler.Handle(deleteCommand);
        }

        public async Task<FilmeDTO> GetFilmesWithRealizadorAsync(int id)
        {
            var filmeEntity = await _query.HandleFilmeWithRealizador(id);
            return _mapper.Map<FilmeDTO>(filmeEntity);
        }

        public async Task<FilmeDTO> GetFilmeAsync(int id)
        {
            var filmeEntity =  await _query.HandleOnlyFilme(id);

            return _mapper.Map<FilmeDTO>(filmeEntity); 
        }

        public async Task<IEnumerable<FilmeDTO>> GetFilmesAsync()
        {
            var filmesEntity = await _query.HandleAllFilme(); 
            return _mapper.Map<IEnumerable<FilmeDTO>>(filmesEntity);
        }

        public async Task UpdateFilmeAsync(FilmeDTO filmeDTO)
        {
            var filmeCommand = _mapper.Map<UpdateFilmeCommand>(filmeDTO); 
            await _handler.Handle(filmeCommand);
           
        }

        public async Task FilmeRealizadorAsync(int filmeId, int realizadorId)
        {
           var filmeRealizadorCommad = new AddRealizadorCommand (filmeId, realizadorId );
            await _handler.Handle (filmeRealizadorCommad);
        }

    }
}