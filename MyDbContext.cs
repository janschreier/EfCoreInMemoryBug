using efCoreSqlLiteInMemory.Tables;
using Microsoft.EntityFrameworkCore;

namespace efCoreSqlLiteInMemory
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<MotorArt>(entity =>
            {
              
                entity.HasMany(d => d.FuelType)
                    .WithMany(p => p.MotorArt)
                    .UsingEntity<Dictionary<string, object>>(
                        "MotorArtKbaKraftstoffCode",
                        l => l.HasOne<FuelType>().WithMany().HasForeignKey("FuelTypeId").OnDelete(DeleteBehavior.ClientSetNull),
                        r => r.HasOne<MotorArt>().WithMany().HasForeignKey("MotorArtId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_MotorArtKbaKraftstoffCode"),
                        j =>
                        {
                            j.HasKey("MotorArtId", "FuelTypeId").HasName("PK_KraftstoffArtKbaKraftstoffCode");

                            j.ToTable("MotorArtKbaKraftstoffCode", "FzgDaten");
                        });

                entity.HasMany(d => d.MotorBauArt)
                    .WithMany(p => p.MotorArt)
                    .UsingEntity<Dictionary<string, object>>(
                        "MotorartMotorbauart",
                        l => l.HasOne<MotorBauart>().WithMany().HasForeignKey("MotorBauArtId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_MotorartMotorbauart2"),
                        r => r.HasOne<MotorArt>().WithMany().HasForeignKey("MotorArtId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_MotorartMotorbauart"),
                        j =>
                        {
                            j.HasKey("MotorArtId", "MotorBauArtId");

                            j.ToTable("MotorartMotorbauart", "FzgDaten");
                        });
            });
        }
    }
}
