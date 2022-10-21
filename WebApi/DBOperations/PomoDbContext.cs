using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

namespace WebApi.DBOperations
{
    public class PomoDbContext : DbContext, IPomoDbContext
    {
        public PomoDbContext(DbContextOptions options): base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Pomodoro> Pomodoros { get; set; }
        public DbSet<MinuteSet> MinuteSets { get; set; }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}