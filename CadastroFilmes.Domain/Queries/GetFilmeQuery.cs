using CadastroFilmes.Domain.Entities;
using System.Linq.Expressions;

namespace CadastroFilmes.Domain.Queries
{
    public static class GetFilmeQuery
    {
        public static Expression<Func<Filme,bool >> GetQueryFilmesById(int id)
        {
            return x=>x.Id == id;
        }

        public static Expression<Func<Filme, bool>> GetQueryAllFilme()
        {
            return filme => true;  
        }
    }
}
