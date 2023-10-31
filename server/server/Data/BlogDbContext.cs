using Microsoft.EntityFrameworkCore;
using server.Data;

namespace server.Data
{
    public class BlogDbContext : DbContext
    {
        public virtual DbSet<Posts> Posts { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Comments> Comments { get; set; }
        public virtual DbSet<LikePostComments> LikePostComments { get; set; }
        public virtual DbSet<Suggestions> suggestions { get; set; }
        public virtual DbSet<Attachments> attachments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(@"Data Source=.;Initial Catalog=BlogDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

    
    }
}
