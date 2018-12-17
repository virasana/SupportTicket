using Microsoft.EntityFrameworkCore;
using ST.SharedUserEntitiesLib;

namespace ST.UsersRepoLib
{
    public class UsersDbContext : DbContext
    {
        private readonly string _connectionString;
        public UsersDbContext(DbContextOptions<UsersDbContext> options) : base(options){}
        public DbSet<User> Users { get; set; }

        public UsersDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(user =>
            {
                user.Property(p => p.Id)
                    .IsRequired();
                user.HasKey(p => p.Id);
                user.HasIndex(p => p.Id)
                    .HasName("IX_UserId");
            });

            modelBuilder.Entity<User>().HasData(new User()
            {
                Id = 1,
                Username = "test",
                FirstName = "Harry",
                LastName = "Potter",
                Password = "test",
                Token = ""
            });
        }
    }
}