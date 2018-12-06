using Lessplastic.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LessplasticWebApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<LessplasticUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Article> Articles { get; set; }

        public DbSet<Poll> Polls { get; set; }

        public DbSet<Answer> Answers { get; set; }
        
        public DbSet<PollsUsers> PollsUsers { get; set; }

        public DbSet<Education> Educations { get; set; }

        public DbSet<Event> Events { get; set; }

        public DbSet<EventTowns> EventsTowns { get; set; }

        public DbSet<Town> Towns { get; set; }

        public DbSet<UserEvents> UsersEvents { get; set; }

        public DbSet<Video> Videos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<PollsUsers>().HasKey(x => new { x.LessplasticUserId, x.PollId });
            
            builder.Entity<UserEvents>(x =>
            {
                x.HasKey(e => new { e.EventId, e.LessplasticUserId });
                
                x.HasOne(e => e.LessplasticUser)
                 .WithMany(e => e.Events)
                 .HasForeignKey(e => e.LessplasticUserId)
                 .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<EventTowns>(x =>
            {
                x.HasKey(e => new { e.EventId, e.TownId });

                x.HasOne(e => e.Town)
                 .WithMany(e => e.Events)
                 .HasForeignKey(e => e.TownId)
                 .OnDelete(DeleteBehavior.Restrict);
            });

            base.OnModelCreating(builder);
        }
    }
}
