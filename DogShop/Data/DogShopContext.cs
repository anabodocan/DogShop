using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DogShop.Models;

namespace DogShop.Data
{
    public class DogShopContext : DbContext
    {
        public DogShopContext (DbContextOptions<DogShopContext> options)
            : base(options)
        {
        }

        public DbSet<DogShop.Models.Dog> Dog { get; set; }

        public DbSet<DogShop.Models.Breeder> Breeder { get; set; }

        public DbSet<DogShop.Models.Category> Category { get; set; }
    }
}
