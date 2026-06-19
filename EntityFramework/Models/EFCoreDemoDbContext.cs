using EntityFramework.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace EntityFramework.Data
{
    public class EFCoreDemoDbContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<BlogType> BlogTypes { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostType> PostTypes { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=Assignment1;Trusted_Connection=True;TrustServerCertificate=True;");
            //Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure relationships and constraints if needed
            modelBuilder.Entity<Blog>()
                .HasOne(b => b.BlogType)
                .WithMany(bt => bt.Blogs)
                .HasForeignKey(b => b.BlogTypeId);
            modelBuilder.Entity<Post>()
                .HasOne(p => p.Blog)
                .WithMany(b => b.Posts)
                .HasForeignKey(p => p.BlogId);
            modelBuilder.Entity<Post>()
                .HasOne(p => p.PostType)
                .WithMany(pt => pt.Posts)
                .HasForeignKey(p => p.PostTypeId);
            modelBuilder.Entity<Post>()
                .HasOne(p => p.User)
                .WithMany(u => u.Posts)
                .HasForeignKey(p => p.UserId);
        }
    }




}