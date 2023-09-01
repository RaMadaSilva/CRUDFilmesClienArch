using Flunt.Validations;

namespace CadastroFilmes.Domain.Entities
{
    public sealed class Realizador : Entity
    {
        private Realizador()
        {
            
        }
        private List<Filme> _filmes;

        public Realizador(string name, int age)
        {
            AddNotifications(new Contract<Realizador>()
                .Requires()
                .IsGreaterThan(name, 6, "name", "O nome do realizador deve ter mais de 6 caracteres")
                .IsGreaterThan(age, 18, "age", "O realizador deve ter mairo idade")); 
            Name = name;
            Age = age;

            _filmes = new(); 
        }

        public string Name { get; private set; }
        public int Age { get; private set; }

        public ICollection<Filme> Filmes { get => _filmes; }

       public void AddFilme(Filme filme)
        {
            _filmes.Add(filme);
        }

        public void UpdateRealizador(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }
}
