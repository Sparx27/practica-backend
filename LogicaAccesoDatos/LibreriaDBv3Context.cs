using LogicaNegocio.Entidades;
using LogicaNegocio.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoDatos
{
    public class LibreriaDBv3Context : DbContext
    {
        public DbSet<Pais> Paises { get; set; }
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Editorial> Editoriales { get; set; }
        public DbSet<Publicacion> Publicaciones {  get; set; }

        public LibreriaDBv3Context(DbContextOptions opts) : base(opts) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pais>()
                .ToTable("Paises")
                .OwnsOne(p => p.Nombre, opts =>
                {
                    opts.Property(r => r.Valor)
                        .HasColumnName("Nombre")
                        .IsRequired();


                    opts.HasIndex(r => r.Valor)
                        .IsUnique();
                });

            modelBuilder.Entity<Autor>()
                .OwnsOne(a => a.Nombre, opts =>
                {
                    opts.HasIndex(r => r.Valor)
                        .IsUnique();
                });

            modelBuilder.Entity<Editorial>()
                .Property(e => e.Nombre)
                .HasMaxLength(40);

            modelBuilder.Entity<Publicacion>()
                .OwnsOne(p => p.Nombre, opts =>
                {
                    opts.Property(r => r.Valor)
                        .HasColumnName("Nombre")
                        .IsRequired();

                    opts.HasIndex(r => r.Valor)
                    .IsUnique();
                });

            modelBuilder.Entity<Publicacion>()
                .Property(p => p.Antiguedad)
                .HasConversion(
                    adb => adb.ToString(),
                    a => (Antiguedad)Enum.Parse(typeof(Antiguedad), a));

            base.OnModelCreating(modelBuilder);
        }
    }
}
