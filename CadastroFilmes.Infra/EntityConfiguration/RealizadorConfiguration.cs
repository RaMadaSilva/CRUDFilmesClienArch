using CadastroFilmes.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CadastroFilmes.Infra.EntityConfiguration
{
    public class RealizadorConfiguration : IEntityTypeConfiguration<Realizador>
    {
        public void Configure(EntityTypeBuilder<Realizador> builder)
        {
            builder.ToTable("Realizador"); 

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Age).IsRequired();

            //Relacionamento de muitos para muitos

            builder.HasMany(x => x.Filmes)
                .WithMany(x => x.Realizadors)
                .UsingEntity<Dictionary<string, object>>("FilmeRealizador", 
                    filme=>filme
                        .HasOne<Filme>()
                        .WithMany()
                        .HasForeignKey("FilmeId")
                        .OnDelete(DeleteBehavior.NoAction), 
                    realizaor =>realizaor
                        .HasOne<Realizador>()
                        .WithMany()
                        .HasForeignKey("RealizadorId")
                        .OnDelete(DeleteBehavior.NoAction)); 
        }
    }
}
