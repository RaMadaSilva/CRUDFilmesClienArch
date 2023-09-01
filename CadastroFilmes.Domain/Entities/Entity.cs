using Flunt.Notifications;

namespace CadastroFilmes.Domain.Entities
{
    public abstract class Entity : Notifiable<Notification>
    {
        public int Id { get; protected set; }
    }
}
