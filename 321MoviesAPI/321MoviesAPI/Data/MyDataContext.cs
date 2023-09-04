using _321MoviesAPI.Modle;
using _321MoviesAPI.Modles;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace _321MoviesAPI.Data
{
    public class MyDataContext : DbContext
    {
        public MyDataContext(DbContextOptions<MyDataContext> options) : base(options) { }

        public DbSet<Catagory> Catagories => Set<Catagory>();
        public DbSet<Directors> directors => Set<Directors>();
        public DbSet<Movies> moviess => Set<Movies>();
        public DbSet<users> Users => Set<users>();
    }
}

