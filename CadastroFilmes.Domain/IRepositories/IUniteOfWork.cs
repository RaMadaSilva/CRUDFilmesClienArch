namespace CadastroFilmes.Domain.IRepositories
{
    public interface IUniteOfWork
    {
        public IFilmeRepository FilmeRepository { get;}
        public IRealizadorRepository RealizadorRepository { get; }
        Task CommitAsync(); 
    }
}
