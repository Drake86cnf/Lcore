using System;
using System.Configuration;
using Lcore.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;


namespace Lcore.Data
{
    public partial class LCoreContext : DbContext
    {
        // public LCoreContext()
        // {
        // }

        public LCoreContext(DbContextOptions<LCoreContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Comprobante> Comprobante { get; set; }
        public virtual DbSet<Contacto> Contacto { get; set; }
        public virtual DbSet<ContactoImagen> ContactoImagen { get; set; }
        public virtual DbSet<Domicilio> Domicilio { get; set; }
        public virtual DbSet<EntidadFiscalContacto> EntidadFiscalContacto { get; set; }
        public virtual DbSet<EntidadFiscal> EntidadFiscal { get; set; }
        public virtual DbSet<Localidad> Localidad { get; set; }
        public virtual DbSet<SituacionTributaria> SituacionTributaria { get; set; }
        public virtual DbSet<TipoIdentificacion> TipoIdentificacion { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // optionsBuilder.UseMySql("treattinyasboolean=true", x => x.ServerVersion("10.3.14-mariadb"));
                optionsBuilder.UseMySql(ConfigurationManager.ConnectionStrings["LCoreConnection"].ConnectionString + "treattinyasboolean=true; " , x => x.ServerVersion("10.3.14-mariadb"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comprobante>(entity =>
            {
                entity.ToTable("comprobantes");

                entity.HasIndex(e => e.LocalidadId)
                    .HasName("IDX_18EDF3E967707C89");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Acronimo)
                    .IsRequired()
                    .HasColumnName("acronimo")
                    .HasColumnType("varchar(8)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.Discrimina).HasColumnName("discrimina");

                entity.Property(e => e.FechaCreado)
                    .HasColumnName("fecha_creado")
                    .HasColumnType("datetime");

                entity.Property(e => e.FechaEditado)
                    .HasColumnName("fecha_editado")
                    .HasColumnType("datetime");

                entity.Property(e => e.LocalidadId)
                    .HasColumnName("localidad_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasColumnType("varchar(64)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Nota)
                    .HasColumnName("nota")
                    .HasColumnType("varchar(124)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.HasOne(d => d.Localidad)
                    .WithMany(p => p.Comprobante)
                    .HasForeignKey(d => d.LocalidadId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_18EDF3E967707C89");
            });

            modelBuilder.Entity<Contacto>(entity =>
            {
                entity.ToTable("contactos");

                entity.HasIndex(e => e.ImagenId)
                    .HasName("UNIQ_3446F2C5763C8AA7")
                    .IsUnique();

                entity.HasIndex(e => e.LocalidadId)
                    .HasName("IDX_3446F2C567707C89");

                entity.HasIndex(e => e.TipoIdentificacionId)
                    .HasName("IDX_3446F2C565478DC6");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.Apellidos)
                    .IsRequired()
                    .HasColumnName("apellidos")
                    .HasColumnType("varchar(64)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.FechaCreado)
                    .HasColumnName("fecha_creado")
                    .HasColumnType("datetime");

                entity.Property(e => e.FechaEditado)
                    .HasColumnName("fecha_editado")
                    .HasColumnType("datetime");

                entity.Property(e => e.FechaNacimiento)
                    .HasColumnName("fecha_nacimiento")
                    .HasColumnType("date");

                entity.Property(e => e.Genero)
                    .HasColumnName("genero")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.ImagenId)
                    .HasColumnName("imagen_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.LocalidadId)
                    .HasColumnName("localidad_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Nombres)
                    .IsRequired()
                    .HasColumnName("nombres")
                    .HasColumnType("varchar(64)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Nota)
                    .HasColumnName("nota")
                    .HasColumnType("varchar(124)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.NumeroIdentificacion)
                    .HasColumnName("numero_identificacion")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TipoIdentificacionId)
                    .HasColumnName("tipo_identificacion_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Imagen)
                    .WithOne(p => p.Contacto)
                    .HasForeignKey<Contacto>(d => d.ImagenId)
                    .HasConstraintName("FK_3446F2C5763C8AA7");

                entity.HasOne(d => d.Localidad)
                    .WithMany(p => p.Contacto)
                    .HasForeignKey(d => d.LocalidadId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_3446F2C567707C89");

                entity.HasOne(d => d.TipoIdentificacion)
                    .WithMany(p => p.Contacto)
                    .HasForeignKey(d => d.TipoIdentificacionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_3446F2C565478DC6");
            });

            modelBuilder.Entity<ContactoImagen>(entity =>
            {
                entity.ToTable("contactos_imagenes");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.FechaCreado)
                    .HasColumnName("fecha_creado")
                    .HasColumnType("datetime");

                entity.Property(e => e.FechaEditado)
                    .HasColumnName("fecha_editado")
                    .HasColumnType("datetime");

                entity.Property(e => e.Imagen)
                    .HasColumnName("imagen")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Nota)
                    .HasColumnName("nota")
                    .HasColumnType("varchar(124)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");
            });

            modelBuilder.Entity<Domicilio>(entity =>
            {
                entity.ToTable("domicilios");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.Barrio)
                    .HasColumnName("barrio")
                    .HasColumnType("varchar(128)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Departamento)
                    .HasColumnName("departamento")
                    .HasColumnType("varchar(4)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.FechaCreado)
                    .HasColumnName("fecha_creado")
                    .HasColumnType("datetime");

                entity.Property(e => e.FechaEditado)
                    .HasColumnName("fecha_editado")
                    .HasColumnType("datetime");

                entity.Property(e => e.Idrow)
                    .HasColumnName("idrow")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.Latitud)
                    .HasColumnName("latitud")
                    .HasColumnType("decimal(32,16)");

                entity.Property(e => e.Localidad)
                    .HasColumnName("localidad")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.Longitud)
                    .HasColumnName("longitud")
                    .HasColumnType("decimal(32,16)");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasColumnType("varchar(128)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Nota)
                    .HasColumnName("nota")
                    .HasColumnType("varchar(124)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Numero)
                    .HasColumnName("numero")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.Piso)
                    .HasColumnName("piso")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.Tabla)
                    .IsRequired()
                    .HasColumnName("tabla")
                    .HasColumnType("varchar(64)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");
            });

            modelBuilder.Entity<EntidadFiscalContacto>(entity =>
            {
                entity.HasKey(e => new { e.EntidadFiscalId, e.ContactoId })
                    .HasName("PRIMARY");

                entity.ToTable("entidad_fiscal_contacto");

                entity.HasIndex(e => e.ContactoId)
                    .HasName("IDX_E9D818766B505CA9");

                entity.HasIndex(e => e.EntidadFiscalId)
                    .HasName("IDX_E9D81876D3FCA8FD");

                entity.Property(e => e.EntidadFiscalId)
                    .HasColumnName("entidad_fiscal_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ContactoId)
                    .HasColumnName("contacto_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Contacto)
                    .WithMany(p => p.EntidadFiscalContacto)
                    .HasForeignKey(d => d.ContactoId)
                    .HasConstraintName("FK_E9D818766B505CA9");

                entity.HasOne(d => d.EntidadFiscal)
                    .WithMany(p => p.EntidadFiscalContacto)
                    .HasForeignKey(d => d.EntidadFiscalId)
                    .HasConstraintName("FK_E9D81876D3FCA8FD");
            });

            modelBuilder.Entity<EntidadFiscal>(entity =>
            {
                entity.ToTable("entidadesfiscales");

                entity.HasIndex(e => e.LocalidadId)
                    .HasName("IDX_D2C3743A67707C89");

                entity.HasIndex(e => e.SituacionTributariaId)
                    .HasName("IDX_D2C3743AC1DD825F");

                entity.HasIndex(e => e.TipoIdentificacionId)
                    .HasName("IDX_D2C3743A65478DC6");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.Comprobante)
                    .HasColumnName("comprobante")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Domicilio)
                    .IsRequired()
                    .HasColumnName("domicilio")
                    .HasColumnType("varchar(128)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.FechaCreado)
                    .HasColumnName("fecha_creado")
                    .HasColumnType("datetime");

                entity.Property(e => e.FechaEditado)
                    .HasColumnName("fecha_editado")
                    .HasColumnType("datetime");

                entity.Property(e => e.LocalidadId)
                    .HasColumnName("localidad_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.NombreFantasia)
                    .HasColumnName("nombre_fantasia")
                    .HasColumnType("varchar(64)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Nota)
                    .HasColumnName("nota")
                    .HasColumnType("varchar(124)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.NumeroIdentificacionFiscal)
                    .IsRequired()
                    .HasColumnName("numero_identificacion_fiscal")
                    .HasColumnType("varchar(32)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.RazonSocial)
                    .IsRequired()
                    .HasColumnName("razon_social")
                    .HasColumnType("varchar(64)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.SituacionTributariaId)
                    .HasColumnName("situacion_tributaria_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TipoIdentificacionId)
                    .HasColumnName("tipo_identificacion_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Localidad)
                    .WithMany(p => p.EntidadFiscal)
                    .HasForeignKey(d => d.LocalidadId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_D2C3743A67707C89");

                entity.HasOne(d => d.SituacionTributaria)
                    .WithMany(p => p.EntidadFiscal)
                    .HasForeignKey(d => d.SituacionTributariaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_D2C3743AC1DD825F");

                entity.HasOne(d => d.TipoIdentificacion)
                    .WithMany(p => p.EntidadFiscal)
                    .HasForeignKey(d => d.TipoIdentificacionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_D2C3743A65478DC6");
            });

            modelBuilder.Entity<Localidad>(entity =>
            {
                entity.ToTable("localidades");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.CodigoPostal)
                    .HasColumnName("codigo_postal")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CodigoTelefonico)
                    .HasColumnName("codigo_telefonico")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.FechaCreado)
                    .HasColumnName("fecha_creado")
                    .HasColumnType("datetime");

                entity.Property(e => e.FechaEditado)
                    .HasColumnName("fecha_editado")
                    .HasColumnType("datetime");

                entity.Property(e => e.Iso)
                    .HasColumnName("iso")
                    .HasColumnType("varchar(32)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Iso2)
                    .HasColumnName("iso2")
                    .HasColumnType("varchar(4)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Latitud)
                    .HasColumnName("latitud")
                    .HasColumnType("decimal(32,28)");

                entity.Property(e => e.Longitud)
                    .HasColumnName("longitud")
                    .HasColumnType("decimal(32,28)");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasColumnType("varchar(64)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Nota)
                    .HasColumnName("nota")
                    .HasColumnType("varchar(124)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Parent)
                    .HasColumnName("parent")
                    .HasColumnType("smallint(6)");
            });

            modelBuilder.Entity<SituacionTributaria>(entity =>
            {
                entity.ToTable("situacionestributarias");

                entity.HasIndex(e => e.LocalidadId)
                    .HasName("IDX_DE1BE6A667707C89");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Acronimo)
                    .IsRequired()
                    .HasColumnName("acronimo")
                    .HasColumnType("varchar(8)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.FechaCreado)
                    .HasColumnName("fecha_creado")
                    .HasColumnType("datetime");

                entity.Property(e => e.FechaEditado)
                    .HasColumnName("fecha_editado")
                    .HasColumnType("datetime");

                entity.Property(e => e.LocalidadId)
                    .HasColumnName("localidad_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasColumnType("varchar(64)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.NombreAbreviado)
                    .IsRequired()
                    .HasColumnName("nombre_abreviado")
                    .HasColumnType("varchar(32)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Nota)
                    .HasColumnName("nota")
                    .HasColumnType("varchar(124)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.HasOne(d => d.Localidad)
                    .WithMany(p => p.SituacionTributaria)
                    .HasForeignKey(d => d.LocalidadId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DE1BE6A667707C89");
            });

            modelBuilder.Entity<TipoIdentificacion>(entity =>
            {
                entity.ToTable("tiposidentificaciones");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Acronimo)
                    .IsRequired()
                    .HasColumnName("acronimo")
                    .HasColumnType("varchar(8)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.EsFiscal).HasColumnName("es_fiscal");

                entity.Property(e => e.FechaCreado)
                    .HasColumnName("fecha_creado")
                    .HasColumnType("datetime");

                entity.Property(e => e.FechaEditado)
                    .HasColumnName("fecha_editado")
                    .HasColumnType("datetime");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasColumnType("varchar(64)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Nota)
                    .HasColumnName("nota")
                    .HasColumnType("varchar(124)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.ToTable("usuarios");

                entity.HasIndex(e => e.ConfirmationToken)
                    .HasName("UNIQ_EF687F2C05FB297")
                    .IsUnique();

                entity.HasIndex(e => e.EmailCanonical)
                    .HasName("UNIQ_EF687F2A0D96FBF")
                    .IsUnique();

                entity.HasIndex(e => e.UsernameCanonical)
                    .HasName("UNIQ_EF687F292FC23A8")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ConfirmationToken)
                    .HasColumnName("confirmation_token")
                    .HasColumnType("varchar(180)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasColumnType("varchar(180)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.EmailCanonical)
                    .IsRequired()
                    .HasColumnName("email_canonical")
                    .HasColumnType("varchar(180)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Enabled).HasColumnName("enabled");

                entity.Property(e => e.LastLogin)
                    .HasColumnName("last_login")
                    .HasColumnType("datetime");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.PasswordRequestedAt)
                    .HasColumnName("password_requested_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.Roles)
                    .IsRequired()
                    .HasColumnName("roles")
                    .HasColumnType("longtext")
                    .HasComment("(DC2Type:array)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Salt)
                    .HasColumnName("salt")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .HasColumnType("varchar(180)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.UsernameCanonical)
                    .IsRequired()
                    .HasColumnName("username_canonical")
                    .HasColumnType("varchar(180)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
