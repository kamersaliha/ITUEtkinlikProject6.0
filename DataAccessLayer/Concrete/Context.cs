using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Context:IdentityDbContext<AppUser, AppRole, int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-654D5N2;database=ITUEtkinlik6.0ProjectDB;integrated security=true");
        }
        public DbSet<Etkinlik> Etkinlikler { get; set; }
        public DbSet<Kampus> Kampusler { get; set; }
        public DbSet<Kategori> Kategoriler { get; set; }
        public DbSet<Salon> Salonlar { get; set; }
        public DbSet<Iletisim> Iletisimler { get; set; }
        public DbSet<YayinTalebi> YayinTalepleri { get; set; }


    }
}
