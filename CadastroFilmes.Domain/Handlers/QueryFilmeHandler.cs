using CadastroFilmes.Domain.Entities;
using CadastroFilmes.Domain.IRepositories;
using CadastroFilmes.Domain.Queries;
using System.Linq;

namespace CadastroFilmes.Domain.Handlers
{
    public  class QueryFilmeHandler
    {
        private readonly IUniteOfWork _uniteOfWork;

        public QueryFilmeHandler(IUniteOfWork uniteOfWork)
        {
            _uniteOfWork = uniteOfWork;
        }

        public async Task<IEnumerable<Filme>> HandleAllFilme()
        {

            //Pegar todos os fimes do banco de dados
            IEnumerable<Filme> filmes = await _uniteOfWork.FilmeRepository.GetFilmesAsync();

            //Executar a Query desejada
            return filmes.AsQueryable().Where(GetFilmeQuery.GetQueryAllFilme()); 
        }

        public async Task<Filme?> HandleOnlyFilme(int id)
        {

            //Pegar todos os fimes do banco de dados
            var filme = await _uniteOfWork.FilmeRepository.GetFilmesAsync();

            //Executar a Query desejada
            return filme
                    .AsQueryable()
                    .Where(GetFilmeQuery.GetQueryFilmesById(id))
                    .FirstOrDefault();
        }

        public async Task<Filme?> HandleFilmeWithRealizador(int id)
        {

            //Pegar todos os fimes do banco de dados
            var filmes = await _uniteOfWork.FilmeRepository.GetFilmesWithRealizadoresAsync();

            //Executar a Query desejada
            return filmes.AsQueryable()
                    .Where(GetFilmeQuery.GetQueryFilmesById(id))
                    .FirstOrDefault();
        }


    }
}
