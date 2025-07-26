using ExcelAndBlazorApp.Dtos;
using Microsoft.EntityFrameworkCore;

namespace ExcelAndBlazorApp.Entities
{
    public class CompanyDbContext : DbContext
    {
        public CompanyDbContext(DbContextOptions<CompanyDbContext> options) : base(options)
        {
            
        }

        public DbSet<Contract> contracts { get; set; }
        public DbSet<Employee> employees { get; set; }
        public DbSet<WorkLog> workLogs { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<OrderItem> orderItems { get; set; }
        public DbSet<Dtos.Summary> summares { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dtos.Summary>(s =>
            {
                s.HasNoKey();   // encja bez primary key, tylko do odczytu
                s.ToView(null);     // brak mapowania encja EF => tabela DB
            });

            // Wybierz wszystkie właściwości decimal w całym modelu
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var decimalProps = entityType.GetProperties()
                    .Where(p => p.ClrType == typeof(decimal) || p.ClrType == typeof(decimal?));

                foreach (var property in decimalProps)
                {
                    property.SetPrecision(18);
                    property.SetScale(2);
                }
            }
        }
    }
}