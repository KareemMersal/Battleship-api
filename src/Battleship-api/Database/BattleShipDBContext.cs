using BattleShip.Api.Domain;
using Microsoft.EntityFrameworkCore;

namespace BattleShip.Api.Database
{
    public class BattleShipDbContext : DbContext
    {
        public BattleShipDbContext(DbContextOptions<BattleShipDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // configures one-to-many relationship
            modelBuilder.Entity<Board>()
                .HasMany(g => g.Ships)
                .WithOne(c => c.Board)
                .HasForeignKey(c => c.BoardId);

            modelBuilder.Entity<Ship>()
                .HasMany(g => g.Cells)
                .WithOne(c => c.Ship)
                .HasForeignKey(c => c.ShipId);
        }

        public DbSet<Board> Boards { get; set; }
        public DbSet<Ship> Ships { get; set; }
        public DbSet<Cell> Cells { get; set; }
    }
}
