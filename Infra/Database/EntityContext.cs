using ComunicadoSinistro.Domain.Entities.ComunicadoSinistro;
using ComunicadoSinistro.Domain.Entities.Usuarios;
using Locacao.Domain.Entities.Usuarios;
using Locacao.Domain.Entities.Veiculo;
using Microsoft.EntityFrameworkCore;

namespace Locacao.Infra.Database
{
    public class EntityContext : DbContext
    {      
        public EntityContext (DbContextOptions<EntityContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //fazer join maroto no banco agencia/veiculo            
        }

        public DbSet<ComunicadoDeSinistro> ComunicadoDeSinistro { get; set; }
        public DbSet<Foto> Foto { get; set; }
        public DbSet<Reboque> Reboque { get; set; }
        public DbSet<Contrato> Contrato { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Condutor> Condutor { get; set; }
        public DbSet<Terceiro> Terceiro { get; set; }
        public DbSet<Veiculo> Veiculo { get; set; }
        
        
    }
}