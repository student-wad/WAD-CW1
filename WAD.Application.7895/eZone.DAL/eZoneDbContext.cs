using eZone.DAL.DBO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eZone.DAL
{
    public class eZoneDbContext:DbContext
    {
        public eZoneDbContext(DbContextOptions<eZoneDbContext> options) : base(options)
        {

        }

        public virtual DbSet<Course> Courses { get; set; }

        public virtual DbSet<Group> Groups { get; set; }        

        public virtual DbSet<Student> Students { get; set; }

        public virtual DbSet<Teacher> Teachers { get; set; }

        public virtual DbSet<Person> People { get; set; }
    }
}
