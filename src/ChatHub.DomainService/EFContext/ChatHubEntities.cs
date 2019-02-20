using ChatHub.Domain.MessageRooms;
using ChatHub.Domain.Messages;
using ChatHub.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace ChatHub.DomainService.EFContext
{
    public sealed class ChatHubEntities : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Connection String");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>().HasIndex(u => u.Mobile).IsUnique();
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Message> Messages { get; set; }

        public DbSet<Domain.MessageRooms.MessageRoom> MessageRooms { get; set; }
    }
}
