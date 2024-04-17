using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApiJWT.Entities;

namespace WebApiJWT.Config
{
    public class ContextBase : IdentityDbContext<ApplicationUser>
    {

        public ContextBase(DbContextOptions<ContextBase> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ApplicationUser>().ToTable("AspNetUsers").HasKey(t => t.Id);

            base.OnModelCreating(builder);
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ObterStringConexao());

                base.OnConfiguring(optionsBuilder);
            }
        }

        //Adicionando Tabelas
        public DbSet<ProductModel> Product { get; set; }

        public string ObterStringConexao()
        {
            return "";
        }
    }
}
