using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Escola.Models.Entities.Mappings
{
    public class EnderecoMappings : IEntityTypeConfiguration<Endereco>
    {
        private const string Name = "escola";
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.ToTable("Endereco");

            builder.Property(x => x.Logradouro)
                .IsRequired()
                .HasColumnName("Logradouro")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(200);

            builder.Property(x => x.Numero)
                .IsRequired()
                .HasColumnName("Numero")
                .HasColumnType("VARCHAR")
                .HasMaxLength(10);

            builder.Property(x => x.Complemento)
                .HasColumnName("Complemento")
                .HasColumnType("VARCHAR")
                .HasMaxLength(100);

            builder.Property(x => x.Bairro)
                .IsRequired()
                .HasColumnName("Bairro")
                .HasColumnType("VARCHAR")
                .HasMaxLength(100);

            builder.Property(x => x.Cidade)
                .IsRequired()
                .HasColumnName("Cidade")
                .HasColumnType("VARCHAR")
                .HasMaxLength(100);

            builder.Property(x => x.Cep)
                .HasColumnName("Cep")
                .HasColumnType("VARCHAR")
                .HasMaxLength(8);

            builder.HasIndex(x => x.Logradouro)
                .IsUnique();

            builder.HasOne(x => x.Aluno)
                .WithMany(x => x.Enderecos)
                .HasForeignKey(x => x.AlunoId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName($"FK_{Name}_endereco_{Name}_aluno");
        }
    }
}
