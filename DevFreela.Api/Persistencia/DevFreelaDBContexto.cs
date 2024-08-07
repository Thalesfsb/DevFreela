using DevFreela.Api.Entidades;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Api.Persistencia
{
    public class DevFreelaDBContexto : DbContext
    {
        public DevFreelaDBContexto(DbContextOptions<DevFreelaDBContexto> options) : base(options) { }

        public DbSet<Projeto> Projetos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Habilidade> Habilidades { get; set; }
        public DbSet<ProjetoComentario> ProjetoComentarios { get; set; }
        public DbSet<UsuarioHabilidade> UsuarioHabilidades { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Projeto>(p =>
            {
                p.HasKey(p => p.Id);

                // Um projeto tem um freelancer
                p.HasOne(p => p.Freelancer)
                    // Freelancer tem varios projetos
                    .WithMany(u => u.AtuandoFreelance)
                    .HasForeignKey(p => p.IdFreelancer)
                    .OnDelete(DeleteBehavior.Cascade);

                // Um projeto tem um unico cliente
                p.HasOne(p => p.Cliente)
                    // Um cliente é dono de varios projetos
                    .WithMany(u => u.DonoProjeto)
                    .HasForeignKey(p => p.IdCliente)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<Usuario>(u =>
            {
                u.HasKey(u => u.Id);
                
                // Um usuario tem muitas habilidades
                u.HasMany(u => u.Habilidades)
                    // Um usuario tem uma unica habilidade
                    .WithOne(uh => uh.UsuarioHabilidades)
                    .HasForeignKey(uh => uh.IdUsuario)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            builder
                .Entity<Habilidade>(e =>
                {
                    e.HasKey(h => h.Id);

                });

            builder.Entity<ProjetoComentario>(e =>
            {
                e.HasKey(e => e.Id);

                // Um comentario tem um projeto
                e.HasOne(e => e.Projeto)
                    // Projeto pode ter muitos comentarios
                    .WithMany(e => e.Comentarios)
                    // Chave estrangeira, que faz um comentario estar relacionado com um projeto
                    .HasForeignKey(e => e.IdProjeto)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            builder
                .Entity<UsuarioHabilidade>(e =>
                {
                    e.HasKey(us => us.Id);

                    // Uma habilidade está com muitas usuarios habilidades
                    e.HasOne(u => u.Habilidade)
                        .WithMany(u => u.UsuariosHabilidades)
                        .HasForeignKey(s => s.IdHabilidade)
                        .OnDelete(DeleteBehavior.Restrict);

                }
            );


        }
    }
}
