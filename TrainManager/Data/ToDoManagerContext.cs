using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class ToDoManagerContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Train> Trains { get; set; }
        public virtual DbSet<Line> Lines { get; set; }

        public virtual DbSet<Ticket> Tickets { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          
            modelBuilder.Entity<Train>()
                .HasMany(train => train.Lines)
                .WithOne(line => line.Train)
                .HasForeignKey(line => line.TrainId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<User>()
                .HasOne(user => user.Ticket)
                .WithOne(ticket => ticket.User)
                .HasForeignKey<Ticket>(user => user.Id)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>()
                .HasData(new User()
                {
                    Id = 1,
                    FirstName = "Administrator",
                    LastName = "Administrator",
                    Username = "admin",
                    Password = "adminpass",
                    IsAdmin = true
                });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-9F6IC4T\\SQLEXPRESS;Database=TrainsManagerDB;Trusted_Connection=True;");
            optionsBuilder.UseLazyLoadingProxies();
            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder.EnableDetailedErrors();
        }
    }
}
