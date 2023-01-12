using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Roman.WebApi.Domain;

#nullable disable

namespace Roman.WebApi.Contexts
{
    public partial class RomanContext : DbContext
    {
        public RomanContext()
        {
        }

        public RomanContext(DbContextOptions<RomanContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Equipe> Equipes { get; set; }
        public virtual DbSet<Projeto> Projetos { get; set; }
        public virtual DbSet<Tema> Temas { get; set; }
        public virtual DbSet<TipoUsuario> TipoUsuarios { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source='DESKTOP-REURDRV'; Initial Catalog= 'Roman'; Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Equipe>(entity =>
            {
                entity.HasKey(e => e.IdEquipe)
                    .HasName("PK__Equipe__D80524124878D3A3");

                entity.ToTable("Equipe");

                entity.HasIndex(e => e.NomeEquipe, "UQ__Equipe__55A6F17F50F07270")
                    .IsUnique();

                entity.Property(e => e.NomeEquipe)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Projeto>(entity =>
            {
                entity.HasKey(e => e.IdProjeto)
                    .HasName("PK__Projeto__B9E1BB5CBCEDA849");

                entity.ToTable("Projeto");

                entity.HasIndex(e => e.Descricao, "UQ__Projeto__008BA9EF1740DFCE")
                    .IsUnique();

                entity.HasIndex(e => e.NomeProjeto, "UQ__Projeto__2C23A026A14FAB43")
                    .IsUnique();

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.NomeProjeto)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdTemaNavigation)
                    .WithMany(p => p.Projetos)
                    .HasForeignKey(d => d.IdTema)
                    .HasConstraintName("FK__Projeto__IdTema__4BAC3F29");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Projetos)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__Projeto__IdUsuar__4AB81AF0");
            });

            modelBuilder.Entity<Tema>(entity =>
            {
                entity.HasKey(e => e.IdTema)
                    .HasName("PK__Tema__9F3A411750BF8BBF");

                entity.ToTable("Tema");

                entity.HasIndex(e => e.NomeTema, "UQ__Tema__795998E2167C31BF")
                    .IsUnique();

                entity.Property(e => e.Ativo).HasDefaultValueSql("((1))");

                entity.Property(e => e.NomeTema)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoUsuario>(entity =>
            {
                entity.HasKey(e => e.IdTipoUsuario)
                    .HasName("PK__TipoUsua__CA04062B840E020A");

                entity.ToTable("TipoUsuario");

                entity.HasIndex(e => e.NomeTipoUsuario, "UQ__TipoUsua__C6FB90A820C77E1C")
                    .IsUnique();

                entity.Property(e => e.NomeTipoUsuario)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Usuario__5B65BF97883DDAD4");

                entity.ToTable("Usuario");

                entity.HasIndex(e => e.Email, "UQ__Usuario__A9D105344D551CF4")
                    .IsUnique();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.NomeUsuario)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("senha");

                entity.HasOne(d => d.IdEquipeNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdEquipe)
                    .HasConstraintName("FK__Usuario__IdEquip__412EB0B6");

                entity.HasOne(d => d.IdTipoUsuarioNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdTipoUsuario)
                    .HasConstraintName("FK__Usuario__IdTipoU__4222D4EF");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
