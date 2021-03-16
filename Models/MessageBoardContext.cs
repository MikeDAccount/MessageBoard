using Microsoft.EntityFrameworkCore;
using MessageBoard.Models;

namespace MessageBoard.Data     // We are accessing the data directory here. There isn't a namespace called Data but it is behind the scenes and is part of the framework.
{
    public class MessageBoardContext : DbContext    //We are inherting DbContext here
    {
        // DbSet is the Entity Framework database entity that represents the table(s). Examples of the tables are below... User, Message, Comment.
        // The information from the models below are what is getting inserted into the database tables.
        public MessageBoardContext (DbContextOptions<MessageBoardContext> options) : base(options) {}    // base allows for instances of options to be used.
        public DbSet<User> User { get; set; }        
        public DbSet<Message> Messages { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}