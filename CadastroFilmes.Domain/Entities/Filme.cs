using CadastroFilmes.Domain.Entities.Enums;
using Flunt.Validations;

namespace CadastroFilmes.Domain.Entities
{
    public sealed class Filme: Entity
    {
        private List<Realizador> _realizadors;
        private Filme()
        {
            _realizadors = new List<Realizador>();
        }

        public Filme(string title, 
            int releaseYear, 
            int durationsInMinute, 
            ECategory category)
        {
            AddNotifications(new Contract<Filme>()
                        .Requires()
                        .IsGreaterThan(title, 3, "title", "O titulo deve conter mais de 3 caracteres")
                        .IsGreaterThan(releaseYear, 1894, "releaseYear", "O ano de lançameno náo deve ser infeirio a 1894")
                        .IsGreaterThan(durationsInMinute, 0, "durationInMinute", "A duração deve ser superior a zero")); 
            Title = title;
            ReleaseYear = releaseYear;
            DurationsInMinute = durationsInMinute;
            Category = category;

            _realizadors = new List<Realizador>(); 
        }

        public string Title { get; private set; }
        public int ReleaseYear { get; private set; }
        public int DurationsInMinute { get; private set; }
        public ECategory Category { get; private set; }

        public ICollection<Realizador> Realizadors { get { return _realizadors; }}

        public void UpdateFilme(string title,int realiseYear, int durationsInMinute, ECategory category)
        {
            Title = title;
            ReleaseYear = realiseYear;
            DurationsInMinute = durationsInMinute;
            Category = category;
        }

        public void AddRealizador(Realizador realizador)
        {
            _realizadors.Add(realizador);
        }
    }
}
