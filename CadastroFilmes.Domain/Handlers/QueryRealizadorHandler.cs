using CadastroFilmes.Domain.Entities;
using CadastroFilmes.Domain.IRepositories;
using CadastroFilmes.Domain.Queries;

namespace CadastroFilmes.Domain.Handlers
{
    public  class QueryRealizadorHandler
    {
        private readonly IUniteOfWork _uow;
        public QueryRealizadorHandler(IUniteOfWork uow)
        {
            _uow = uow;
        }

        public async Task<Realizador?> GetRealizadorQueryAsync(int id)
        {
           var realizadores = await _uow.RealizadorRepository.GetRealizadoresAsync();
           return realizadores
                        .AsQueryable()
                        .Where(GetRealizadorQuery.GetOnlyRealizador(id))
                        .FirstOrDefault(); 
        }

        public async Task<IEnumerable<Realizador>> GetAllRealizadorAsync()
        {
            var realizadores = await _uow.RealizadorRepository.GetRealizadoresAsync();

            return realizadores.AsQueryable().Where(GetRealizadorQuery.GetAllRealizador()); 
        }
    }
}
