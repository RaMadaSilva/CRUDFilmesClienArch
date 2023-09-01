using CadastroFilmes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CadastroFilmes.Domain.Queries
{
    public static class GetRealizadorQuery
    {
        public static Expression<Func<Realizador, bool>> GetAllRealizador()
        {
            return x => true; 
        }

        public static Expression<Func<Realizador, bool>> GetOnlyRealizador(int id)
        {
            return x=>x.Id == id;
        }
    }
}
