using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Models;

namespace RestApi.Data
{
    public class HaandvaerkerDbContext : DbContext
    {
        public DbSet<Haandvaerker> CraftsMen { get; set; }
        public DbSet<Vaerktoejskasse> ToolBoxes { get; set; }
        public DbSet<Vaerktoej> Tools { get; set; }

        public HaandvaerkerDbContext() { }

        public HaandvaerkerDbContext(DbContextOptions<HaandvaerkerDbContext> options)
            : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    "");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            onModelCreatingCraftsMan(modelBuilder);
            onModelCreatingToolBox(modelBuilder);
            onModelCreatingTool(modelBuilder);
            onModelCreatingSeedData(modelBuilder);
        }

        private void onModelCreatingCraftsMan(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Haandvaerker>()
                .HasMany(tb => tb.Vaerktoejskasse)
                .WithOne(hv => hv.EjesAfNavigation)
                .HasForeignKey(x => x.VTKEjesAf)
                .OnDelete(DeleteBehavior.Cascade);

        }

        private void onModelCreatingToolBox(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vaerktoejskasse>()
                .HasMany(x => x.Vaerktoej)
                .WithOne(y => y.LiggerIvtkNavigation)
                .HasForeignKey(z => z.LiggerIvtk)
                .OnDelete(DeleteBehavior.Cascade);
        }

        private void onModelCreatingTool(ModelBuilder modelBuilder)
        {

        }

        private void onModelCreatingSeedData(ModelBuilder modelBuilder)
        {
            Guid jId = Guid.NewGuid();
            Guid mId = Guid.NewGuid();
            Guid redBoxId = Guid.NewGuid();
            Guid blackBoxId = Guid.NewGuid();

            modelBuilder.Entity<Haandvaerker>().HasData(
                new Haandvaerker
                {
                    HaandvaerkerId = jId,
                    HVFornavn = "Jonas",
                    HVEfternavn = "HangMountain",
                    HVAnsaettelsedato = DateTime.Today,
                    HVFagomraade = "Plumber"
                },
                new Haandvaerker
                {
                    HaandvaerkerId = mId,
                    HVFornavn = "Morten",
                    HVEfternavn = "Rosetwig",
                    HVAnsaettelsedato = DateTime.Today,
                    HVFagomraade = "Carpenter"
                }
            );

            modelBuilder.Entity<Vaerktoejskasse>().HasData(
                new Vaerktoejskasse
                {
                    VTKEjesAf = jId,
                    VTKAnskaffet = DateTime.Today,
                    VTKFabrikat = "redBox",
                    VTKModel = "bigBox",
                    VTKFarve = "red",
                    VTKSerienummer = "10101",
                    VTKId = redBoxId
                },
                new Vaerktoejskasse
                {
                    VTKEjesAf = mId,
                    VTKAnskaffet = DateTime.Today,
                    VTKFabrikat = "blackBox",
                    VTKModel = "smallBox",
                    VTKFarve = "black",
                    VTKSerienummer = "01010",
                    VTKId = blackBoxId
                }
            );

            modelBuilder.Entity<Vaerktoej>().HasData(
                new Vaerktoej
                {
                    VTAnskaffet = DateTime.Today,
                    VTType = "Hammer",
                    VTFabrikat = "Mjolner",
                    VTSerienr = "11000",
                    VTModel = "7",
                    VTId = Guid.NewGuid(),
                    LiggerIvtk = redBoxId
                },
                new Vaerktoej
                {
                    VTAnskaffet = DateTime.Today,
                    VTType = "Saw",
                    VTFabrikat = "Biter",
                    VTSerienr = "00111",
                    VTModel = "4",
                    VTId = Guid.NewGuid(),
                    LiggerIvtk = blackBoxId
                }
            );
        }
    }
}
