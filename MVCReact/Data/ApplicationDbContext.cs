using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MVCReact.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCReact.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }
        


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Dane>()
                .HasOne<Produkt>(d => d.Produkt)
                .WithMany(p => p.Danes)
                .HasForeignKey(d => d.ProduktID);

            builder.Entity<Dane>()
                .HasOne<Sklepy>(d => d.Sklep)
                .WithMany(s => s.Danes)
                .HasForeignKey(d => d.SklepID);
        }
        public DbSet<Produkt> Products {get;set;}
        public DbSet<Dane> Danes { get; set; }
        public DbSet<Sklepy> Shops { get; set; }
        public DbSet<Marka> Markas { get; set; }
        

    }
}
