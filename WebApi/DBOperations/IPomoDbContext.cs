using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

namespace WebApi.DBOperations
{
    public interface IPomoDbContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Pomodoro> Pomodoros { get; set; }
        DbSet<MinuteSet> MinuteSets { get; set; }
    }
}