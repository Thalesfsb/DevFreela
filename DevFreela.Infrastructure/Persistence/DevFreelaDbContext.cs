using DevFreela.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace DevFreela.Infrastructure.Persistence
{
    public class DevFreelaDbContext : DbContext
    {
        public DevFreelaDbContext(DbContextOptions<DevFreelaDbContext> options)
            : base(options)
        {

        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<UserSkill> UserSkills { get; set; }
        public DbSet<ProjectComment> ProjectComments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Configura a chave primária de Skill
            builder.Entity<Skill>()
                .HasKey(s => s.Id);

            // Configura a chave primária de UserSkill
            builder.Entity<UserSkill>()
                .HasKey(us => us.Id);

            // Configura o relacionamento um-para-muitos
            builder.Entity<UserSkill>()
                .HasOne(us => us.Skill) // Cada UserSkill tem um Skill
                .WithMany(s => s.UserSkills) // Cada Skill pode ter muitos UserSkills
                .HasForeignKey(us => us.IdSkill) // Define a chave estrangeira para o relacionamento
                .OnDelete(DeleteBehavior.Restrict); // Configura o comportamento de exclusão

            builder
                .Entity<ProjectComment>(e =>
                {
                    e.HasKey(p => p.Id);

                    e.HasOne(p => p.Project)
                        .WithMany(p => p.Comments)
                        .HasForeignKey(p => p.IdProject)
                        .OnDelete(DeleteBehavior.Restrict);

                    e.HasOne(p => p.User)
                        .WithMany(u => u.Comments)
                        .HasForeignKey(p => p.IdUser)
                        .OnDelete(DeleteBehavior.Restrict);
                });

            builder
                .Entity<User>(e =>
                {
                    e.HasKey(u => u.Id);

                    e.HasMany(u => u.Skills)
                        .WithOne(us => us.User)
                        .HasForeignKey(us => us.IdUser)
                        .OnDelete(DeleteBehavior.Restrict);
                });

            builder
                .Entity<Project>(e =>
                {
                    e.HasKey(p => p.Id);

                    e.HasOne(p => p.Freelancer)
                        .WithMany(f => f.FreelanceProjects)
                        .HasForeignKey(p => p.IdFreelancer)
                        .OnDelete(DeleteBehavior.Restrict);

                    e.HasOne(p => p.Client)
                        .WithMany(c => c.OwnedProjects)
                        .HasForeignKey(p => p.IdClient)
                        .OnDelete(DeleteBehavior.Restrict);
                });

            base.OnModelCreating(builder);
        }
    }
}
