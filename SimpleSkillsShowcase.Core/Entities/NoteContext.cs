using Microsoft.EntityFrameworkCore;

namespace SimpleSkillsShowcase.Core.Entities
{
    public class NoteContext : DbContext
    {
        public NoteContext()
        {
        }

        public NoteContext(DbContextOptions<NoteContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Note> Note { get; set; }
        public virtual DbSet<Author> Authors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Note>(entity =>
            {
                entity.Property(n => n.Title)
                .HasMaxLength(20);
            });
        }
    }
}