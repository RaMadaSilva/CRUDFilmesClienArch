using CadastroFilmes.Domain.Commands.Contracts;
using Flunt.Notifications;
using Flunt.Validations;

namespace CadastroFilmes.Domain.Commands
{
    public class InsertRealizadorCommand : Notifiable<Notification>, ICommand
    {
        public InsertRealizadorCommand()
        {
            
        }
        public InsertRealizadorCommand(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string Name { get; set; }
        public int Age { get; set; }

        public void Valid()
        {
            AddNotifications(new Contract<InsertRealizadorCommand>()
            .Requires()
                .IsGreaterThan(Name, 6, "name", "O nome do realizador deve ter mais de 6 caracteres")
                .IsGreaterThan(Age, 18, "age", "O realizador deve ter mairo idade"));
        }
    }
}
