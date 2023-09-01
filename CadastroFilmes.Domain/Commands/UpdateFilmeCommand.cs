using CadastroFilmes.Domain.Commands.Contracts;
using CadastroFilmes.Domain.Entities.Enums;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroFilmes.Domain.Commands
{
    public class UpdateFilmeCommand  : Notifiable<Notification>, ICommand
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int ReleaseYear { get; set; }
        public int DurationsInMinute { get; set; }
        public ECategory Category { get; set; }

        public void Valid()
        {
            AddNotifications(new Contract<InserirFilmeCommand>()
                .Requires()
                .IsGreaterThan(Title, 3, "title", "O titulo deve conter mais de 3 caracteres")
                .IsGreaterThan(ReleaseYear, 1894, "releaseYear", "O ano de lançameno náo deve ser infeirio a 1894")
                .IsGreaterThan(DurationsInMinute, 0, "durationInMinute", "A duração deve ser superior a zero"));
        }
    }
}
