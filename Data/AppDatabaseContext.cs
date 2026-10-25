using Marathon.Api.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Race_Day.Models.Entities;

namespace Marathon.Api.Data
{
    public class AppDatabaseContext : DbContext
    {
        public AppDatabaseContext(DbContextOptions<AppDatabaseContext> options) : base(options)
        {
        }


        public DbSet<Event> Events { get; set; }
        
        public DbSet<Participant> Participants { get; set; }
        public DbSet<Race> Race { get; set; }
        public DbSet<Race_Event> Race_Events { get; set; }
        public DbSet<Registration> Registrations { get; set; }
        public DbSet<Event_Results> Event_Results { get; set; }
        public DbSet<Roles>Roles { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<User> Users { get; set; }
       


    }
}