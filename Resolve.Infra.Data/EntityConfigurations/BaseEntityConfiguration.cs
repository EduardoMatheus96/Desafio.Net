using Resolve.Domain.Registrations.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
namespace Resolve.Infra.Data.EntityConfigurations
{
    public abstract class BaseEntityConfiguration<T> : IEntityTypeConfiguration<T> where T : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(e => e.ProgramacaoFinanceiraDespesaConfigId);

            builder.Property(e => e.ProgramacaoFinanceiraDespesaConfigId)
                .HasColumnType("varchar(36)")
                .IsRequired();
        }
    }
}
