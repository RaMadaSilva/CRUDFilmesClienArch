using CadastroFilmes.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CadastroFilmes.Infra.EntityConfiguration
{
    public class FilmeConfiguration : IEntityTypeConfiguration<Filme>
    {
        public void Configure(EntityTypeBuilder<Filme> builder)
        {
            builder.ToTable("Filme"); 
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();

            builder.Property(x => x.Title).IsRequired().HasMaxLength(100);
            builder.Property(x => x.ReleaseYear).IsRequired(); 
            builder.Property(x => x.DurationsInMinute).IsRequired();
            builder.Property(x => x.Category).IsRequired(); 
        }
    }
}
