using CadastroFilmes.Domain.Commands.Contracts;
using CadastroFilmes.Domain.Entities;
using Flunt.Notifications;
using Flunt.Validations;

namespace CadastroFilmes.Domain.Commands
{
    public class UpdateRealizadorCommand : Notifiable<Notification>, ICommand
    {
        public UpdateRealizadorCommand()
        {
            
        }
        public UpdateRealizadorCommand(int id, string name, int age)
        {
            Id = id;
            Name = name;
            Age = age;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public void Valid()
        {
            AddNotifications(new Contract<UpdateFilmeCommand>()
             .Requires()
                 .IsGreaterThan(Name, 6, "name", "O nome do realizador deve ter mais de 6 caracteres")
                 .IsGreaterThan(Age, 18, "age", "O realizador deve ter mairo idade"));
        }
    }
}
