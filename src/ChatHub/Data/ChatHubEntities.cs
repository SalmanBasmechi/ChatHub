using ChatHub.Models.MessageRooms;
using ChatHub.Models.Messages;
using ChatHub.Models.Users;
using Microsoft.EntityFrameworkCore;

namespace ChatHub.Data.EFContext
{
    public sealed class ChatHubEntities : DbContext
    {
        public ChatHubEntities()
        {
            ChangeTracker.AutoDetectChangesEnabled = false;
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Message> Messages { get; set; }

        public DbSet<MessageRoom> MessageRooms { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=. ; Initial Catalog=ChatHub ; Integrated Security=True ;");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>()
                   .HasIndex(u => u.Mobile)
                   .IsUnique();
        }
    }
}
