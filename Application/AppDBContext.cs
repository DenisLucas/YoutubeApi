using System;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
namespace Application
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options): base(options)
        {

        }

        public DbSet<User> User { get; set; }
        public DbSet<Video> Video { get; set; }
    }
}
