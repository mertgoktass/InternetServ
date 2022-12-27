using DynobilV3.Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynobilV3.DataAccess.Concrete.Contexts
{
    public class BaseContext : IdentityDbContext<Personel>   //Hem identity tablolarini(personel) hem de oteki tablolari birlestirmek icin yaptim
    {
        public BaseContext(DbContextOptions<BaseContext> options) : base(options)
        {

        }
        //optionsBuilder.UseSqlServer(@"Server=LAPTOP-G47JRNGU\BERATSQLSERVER; Database=Basedb; integrated security=true");  MsSql 

        //Personel icin olan tablo yani kullanici icin olan tablo zaten eklenecek identity ile beraber o yuzden yazmiyorum
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<Company> Bayis { get; set; }
    }

}
