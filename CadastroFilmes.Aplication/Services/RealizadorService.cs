using CadastroFilmes.Aplication.DTOs;
using CadastroFilmes.Aplication.IServices;
using CadastroFilmes.Domain.Handlers;
using CadastroFilmes.Domain.Commands;

namespace CadastroFilmes.Aplication.Services
{
    public class RealizadorService : IRealizadorService
    {
        private readonly CommandRealizadorHandler _handler;
        private readonly QueryRealizadorHandler _query;
        //private readonly IMapper _mapper;

        public RealizadorService(CommandRealizadorHandler handler,
                QueryRealizadorHandler query)
        {
            _handler = handler;
            _query = query;
        }

        public async Task AddRealizador(InsertRealizadorCommand command)
        {
            //var realizadorCommand = _mapper.Map<InsertRealizadorCommand>(realizadorDTO);
            await _handler.Handle(command);
        }

        public async Task DeleteRealizador(int id)
        {
            var deletecommand = new DeleteRealizadorCommand(id);
            await _handler.Handle(deletecommand);
        }

        public async Task<RealizadorDTO> GetRealizadoWithFilme(int id)
        {
            var realizadorEntity = await _query.GetRealizadorQueryAsync(id);

            return RealizadorDtoMapper.ToRealizadorDto(realizadorEntity);
          
            //return _mapper.Map<RealizadorDTO>(realizadorEntity); 
        }

        public async Task<RealizadorDTO> GetRealizadorById(int id)
        {
            var realizadorEntity = await _query.GetRealizadorQueryAsync(id);

           return RealizadorDtoMapper.ToRealizadorDto(realizadorEntity); 

            //return _mapper.Map<RealizadorDTO>(realizadorEntity); 

        }

        public async Task<IEnumerable<RealizadorDTO>> GetRealizadores()
        {
            var realizadoresEntity = await _query.GetAllRealizadorAsync();

            return RealizadorDtoMapper.ToRealizadorDtoList(realizadoresEntity); 

            //return _mapper.Map<IEnumerable<RealizadorDTO>>(realizadoresEntity);
        }

        public async Task UpdateRealizador(RealizadorDTO realizadorDto)
        {
            var command = RealizadorDtoMapper.ToUpdateCommand(realizadorDto);
            //var updateRealizadorCommand = _mapper.Map<UpdateRealizadorCommand>(realizadorDTO);
            await _handler.Handle(command);
        }

        public List<string> ObterListaNomes(List<RealizadorDTO> realizadoresDto)
        {
            List<string> names = new List<string>();
            foreach (var realizadorDto in realizadoresDto)
            {
                names.Add(realizadorDto.Name);
            }
            return names;
        }
    }
}
