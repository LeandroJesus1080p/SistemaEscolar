using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Escola.Models.Entities.Mappings
{
    public class AlunoMappings : IEntityTypeConfiguration<Aluno>
    {
        public void Configure(EntityTypeBuilder<Aluno> builder)
        {
            builder.ToTable("Aluno");

            builder.Property(x => x.Nome)
                .IsRequired()
                .HasColumnName("Nome")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(180);

            builder.Property(x => x.DataNascimento)
                .HasColumnName("DataNascimento")
                .HasColumnType("date");

            builder.Property(x => x.Rg)
                .IsRequired()
                .HasColumnName("Rg")
                .HasColumnType("VARCHAR")
                .HasMaxLength(20);

            builder.Property(x => x.Cpf)
                .IsRequired()
                .HasColumnName("Cpf")
                .HasColumnType("VARCHAR")
                .HasMaxLength(11);

            builder.Property(x => x.NomeResponsavel)
                .IsRequired()
                .HasColumnName("NomeResponsavel")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(180);

            builder.HasIndex(x => x.Nome, "IX_Aluno_Nome")
                .IsUnique();
        }
    }
}
