using Microsoft.EntityFrameworkCore;
using MessageBoard.Models;

namespace MessageBoard.Data     // We are access data directory here
{
    public class MessageBoardContext : DbContext    //We are inherting DbContext here
    {
        // DbSet is the database entity that represents the table(s). Examples of the tables are below... User, Message, Comment
        public MessageBoardContext (DbContextOptions<MessageBoardContext> options) : base(options) {}    // base allows for instances of options to be used.
            public DbSet<User> User { get; set; }        
            public DbSet<Message> Messages { get; set; }
            public DbSet<Comment> Meesages { get; set; }

    }
}