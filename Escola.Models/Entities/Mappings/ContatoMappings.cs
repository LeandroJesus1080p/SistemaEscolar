using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Escola.Models.Entities.Mappings
{
    public class ContatoMappings : IEntityTypeConfiguration<Contato>
    {
        private const string Name = "escola";
        public void Configure(EntityTypeBuilder<Contato> builder)
        {
            builder.ToTable("Contato");

            builder.Property(x => x.Telefone)
                .IsRequired()
                .HasColumnName("Telefone")
                .HasColumnType("VARCHAR");

            builder.Property(x => x.Celular)
                .HasColumnName("Celular");

            builder.HasIndex(x => x.Celular);

            builder.HasOne(x => x.Aluno)
                .WithMany(x => x.Contatos)
                .HasForeignKey(x => x.AlunoId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName($"FK_{Name}_contato_{Name}_aluno");
        }
    }
}