using AutoMapper;
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
        private readonly IMapper _mapper;

        public RealizadorService(CommandRealizadorHandler handler, 
                QueryRealizadorHandler query, 
                IMapper mapper)
        {
            _handler = handler;
            _query = query;
            _mapper = mapper;
        }

        public async Task AddRealizador(RealizadorDTO realizadorDTO)
        {
            var realizadorCommand = _mapper.Map<InsertRealizadorCommand>(realizadorDTO);
            await _handler.Handle(realizadorCommand); 
        }

        public async Task DeleteRealizador(int id)
        {
            var deletecommand = new DeleteRealizadorCommand(id);
            await _handler.Handle(deletecommand);  
        }

        public async Task<RealizadorDTO> GetRealizadoWithFilme(int id)
        {
            var realizadorEntity = await _query.GetRealizadorQueryAsync(id);
            return _mapper.Map<RealizadorDTO>(realizadorEntity); 
        }

        public async Task<RealizadorDTO> GetRealizadorById(int id)
        {
            var realizadorEntity = await _query.GetRealizadorQueryAsync(id);
            return _mapper.Map<RealizadorDTO>(realizadorEntity); 

        }

        public async Task<IEnumerable<RealizadorDTO>> GetRealizadores()
        {
            var realizadoresEntity = await _query.GetAllRealizadorAsync();
            return _mapper.Map<IEnumerable<RealizadorDTO>>(realizadoresEntity); 
        }

        public async Task UpdateRealizador(RealizadorDTO realizadorDTO)
        {
            var updateRealizadorCommand = _mapper.Map<UpdateRealizadorCommand>(realizadorDTO);
            await _handler.Handle(updateRealizadorCommand);
        }

        public List<string> ObterListaNomes(List<RealizadorDTO> realizadoresDto)
        {
            List<string> names = new List<string>();
            foreach(var realizadorDto in realizadoresDto)
            {
                  names.Add(realizadorDto.Name);
            }
            return  names;
        }
    }
}
