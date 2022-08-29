using API.Data.Dtos;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class CarteiraContext : DbContext
    {
        public CarteiraContext(DbContextOptions<CarteiraContext> opt) : base(opt)
        {

        }

        public DbSet<Carteira> CarteirasEstudante { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Estudante>(e =>
            {
                e.HasKey(of => of.Id);
            });

            builder.Entity<Carteira>(e =>
            {
                e.HasKey(of => of.Id);
            });

            builder.Entity<Carteira>(e =>
            {
                e.HasKey(of => of.Matricula);
            });
        }
    }
}
