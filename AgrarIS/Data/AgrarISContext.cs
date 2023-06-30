using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AgrarIS.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace AgrarIS.Data
{
    public class AgrarISContext : DbContext
    {
        public AgrarISContext (DbContextOptions<AgrarISContext> options)
            : base(options)
        {
        }

        public DbSet<AgrarIS.Models.Korisnik> Korisnik { get; set; } = default!;

        public DbSet<AgrarIS.Models.Sluzbenik> Sluzbenik { get; set; } = default!;

        public DbSet<AgrarIS.Models.Parcela> Parcela { get; set; } = default!;

        public DbSet<AgrarIS.Models.Pesticid> Pesticid { get; set; } = default!;

        public DbSet<AgrarIS.Models.PoljoprivrednoDobro> PoljoprivrednoDobro { get; set; } = default!;

        public DbSet<AgrarIS.Models.Subvencija> Subvencija { get; set; } = default!;

        public DbSet<AgrarIS.Models.Vocnjak> Vocnjak { get; set; } = default!;

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Vocnjak>().HasOne(a => a.PoljoprivrednoDobro).WithOne(x => x.Vocnjak).HasForeignKey("PoljoprivrednoDobroId");
        //    base.OnModelCreating(modelBuilder);
        //}
    }
}
