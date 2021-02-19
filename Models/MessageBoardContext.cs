using Microsoft.EntityFrameworkCore;
using MessageBoard.Models;

namespace MessageBoard.Data     // We are access data directory here
{
    public class MessageBoardContext : DbContext    //We are inherting DbContext here
    {
        public MessageBoardContext (DbContextOptions<MessageBoardContext> options) : base(options) {}    // base allows for instances of options to be used.
            public DbSet<User> User { get; set; }        
    }
}