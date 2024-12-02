using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AnimalAPI.Model;

namespace AnimalAPI.Data
{
    public class AnimalAPIContext : DbContext
    {
        public AnimalAPIContext (DbContextOptions<AnimalAPIContext> options)
            : base(options)
        {
        }

        public DbSet<AnimalAPI.Model.Animal> Animal { get; set; } = default!;
    }
}
