using Duende.IdentityServer.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using PetHelp.Server.Models;

namespace PetHelp.Server.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }
        public DbSet<Hodowla> ListaHodowli { get; set; }
        public DbSet<Zwierze> Zwierzeta { get; set; }
        public DbSet<Zalacznik> Zalaczniks { get; set; }
        public DbSet<rasa_psa> rasy_psow { get; set; }
    }
}