using MasterData.Storage.DBInitialize;
using MasterData.Storage.Enities;
using Microsoft.EntityFrameworkCore;

namespace ProleiT.OeeBaseClassifiers.Storage
{
    public class MasterDataContext : DbContext
    {
        public DbSet<Unit> Units { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<CounterTrend> CounterTrend { get; set; }
        public DbSet<ParameterTrend> ParameterTrend { get; set; }
        public DbSet<Trend> Trend { get; set; }
        public MasterDataContext(DbContextOptions<MasterDataContext> options) : base(options){}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            #region Inserting data

            DBInitializeHelper.InsertInitialData(modelBuilder);

            #endregion

            modelBuilder.Entity<Unit>()
              .HasAlternateKey(c => c.Key);

            modelBuilder.Entity<Equipment>()
               .HasAlternateKey(c => c.Key);

            modelBuilder.Entity<CounterTrend>()
               .HasAlternateKey(c => c.Key);

            modelBuilder.Entity<ParameterTrend>()
               .HasAlternateKey(c => c.Key);

            modelBuilder.Entity<Trend>()
               .HasAlternateKey(c => c.Key);

            #region Deleting Rules

            modelBuilder.Entity<ParameterTrend>()
                .HasOne(x => x.Trend)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<CounterTrend>()
                .HasOne(x => x.Trend)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            #endregion
        }
    }
}
