using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Escola.Models.Entities.Mappings
{
    public class ProfessorMappings : IEntityTypeConfiguration<Professor>
    {
        public void Configure(EntityTypeBuilder<Professor> builder)
        {
            builder.ToTable("Professor");

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

            builder.Property(x => x.Email)
                .HasColumnName("Email")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(200);

            builder.Property(x => x.Telefone)
                .HasColumnName("Telefone")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(16);

            builder.Property(x => x.Formacao)
                .HasColumnName("Formacao")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(120);

        }
    }
}
