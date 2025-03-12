using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using Resolve.Domain.Registrations.Entities;
using Resolve.Infra.Data.EntityConfigurations;
using Resolve.Infra.Data.Models;

namespace Resolve.Infra.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
     
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new ProgramacaoFinanceiraDespesaConfigConfiguration());

        }

        public DbSet<ProgramacaoFinanceiraDespesaConfig> ProgramacaoFinanceiraDespesaConfig { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<OrcamentoDespesa> OrcamentoDespesa { get; set; }

    }
}
