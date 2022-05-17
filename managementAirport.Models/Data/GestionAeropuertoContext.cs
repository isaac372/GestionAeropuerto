using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace managementAirport.Models.Data
{
    public partial class GestionAeropuertoContext : DbContext
    {
        public GestionAeropuertoContext()
        {
        }

        public GestionAeropuertoContext(DbContextOptions<GestionAeropuertoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Aerolinea> Aerolineas { get; set; }
        public virtual DbSet<Aeropuerto> Aeropuertos { get; set; }
        public virtual DbSet<Agencium> Agencia { get; set; }
        public virtual DbSet<Asiento> Asientos { get; set; }
        public virtual DbSet<Avion> Avions { get; set; }
        public virtual DbSet<Departamento> Departamentos { get; set; }
        public virtual DbSet<Destino> Destinos { get; set; }
        public virtual DbSet<Equipaje> Equipajes { get; set; }
        public virtual DbSet<Escala> Escalas { get; set; }
        public virtual DbSet<Escala1> Escalas1 { get; set; }
        public virtual DbSet<Flotilla> Flotillas { get; set; }
        public virtual DbSet<Modulo> Modulos { get; set; }
        public virtual DbSet<Operacione> Operaciones { get; set; }
        public virtual DbSet<Origen> Origens { get; set; }
        public virtual DbSet<Pai> Pais { get; set; }
        public virtual DbSet<Pasajero> Pasajeros { get; set; }
        public virtual DbSet<Pasajeroreserva> Pasajeroreservas { get; set; }
        public virtual DbSet<Reserva> Reservas { get; set; }
        public virtual DbSet<Rol> Rols { get; set; }
        public virtual DbSet<RolOperacion> RolOperacions { get; set; }
        public virtual DbSet<Rutum> Ruta { get; set; }
        public virtual DbSet<Tarifa> Tarifas { get; set; }
        public virtual DbSet<Tripulacion> Tripulacions { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<Vuelo> Vuelos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\;Database=GestionAeropuerto;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Aerolinea>(entity =>
            {
                entity.ToTable("aerolinea");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Aeropuerto>(entity =>
            {
                entity.ToTable("Aeropuerto");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdDepartamento).HasColumnName("idDepartamento");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.HasOne(d => d.IdDepartamentoNavigation)
                    .WithMany(p => p.Aeropuertos)
                    .HasForeignKey(d => d.IdDepartamento)
                    .HasConstraintName("FK_Aeropuerto_Departamentos");
            });

            modelBuilder.Entity<Agencium>(entity =>
            {
                entity.ToTable("AGENCIA");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Idaerolineas).HasColumnName("IDAEROLINEAS");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRE");

                entity.HasOne(d => d.IdaerolineasNavigation)
                    .WithMany(p => p.Agencia)
                    .HasForeignKey(d => d.Idaerolineas)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AGENCIA_aerolinea");
            });

            modelBuilder.Entity<Asiento>(entity =>
            {
                entity.ToTable("ASIENTO");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Estado)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("estado");

                entity.Property(e => e.IdVuelo).HasColumnName("idVuelo");
            });

            modelBuilder.Entity<Avion>(entity =>
            {
                entity.HasKey(e => e.IdAvion)
                    .HasName("PK__Avion__66D8A4F33F55DFC5");

                entity.ToTable("Avion");

                entity.Property(e => e.IdAvion).HasColumnName("id_avion");

                entity.Property(e => e.IdFlotilla).HasColumnName("id_flotilla");

                entity.Property(e => e.Modelo)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("modelo");

                entity.Property(e => e.Placa)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("placa");

                entity.HasOne(d => d.IdFlotillaNavigation)
                    .WithMany(p => p.Avions)
                    .HasForeignKey(d => d.IdFlotilla)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_id_flotilla");
            });

            modelBuilder.Entity<Departamento>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Idpais).HasColumnName("idpais");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.HasOne(d => d.IdpaisNavigation)
                    .WithMany(p => p.Departamentos)
                    .HasForeignKey(d => d.Idpais)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Departamentos_Pais");
            });

            modelBuilder.Entity<Destino>(entity =>
            {
                entity.ToTable("Destino");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Idaeropuerto).HasColumnName("idaeropuerto");

                entity.HasOne(d => d.IdaeropuertoNavigation)
                    .WithMany(p => p.Destinos)
                    .HasForeignKey(d => d.Idaeropuerto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Destino_Aeropuerto");
            });

            modelBuilder.Entity<Equipaje>(entity =>
            {
                entity.ToTable("EQUIPAJE");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.Property(e => e.IdPasajero).HasColumnName("idPasajero");

                entity.Property(e => e.Peso).HasColumnName("peso");

                entity.HasOne(d => d.IdPasajeroNavigation)
                    .WithMany(p => p.Equipajes)
                    .HasForeignKey(d => d.IdPasajero)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_id_equipaje");
            });

            modelBuilder.Entity<Escala>(entity =>
            {
                entity.ToTable("Escala");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.Property(e => e.IdVuelo).HasColumnName("idVuelo");

                entity.Property(e => e.Tiempo)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("tiempo");

                entity.HasOne(d => d.IdVueloNavigation)
                    .WithMany(p => p.Escalas)
                    .HasForeignKey(d => d.IdVuelo)
                    .HasConstraintName("FK_Escala_Vuelo");
            });

            modelBuilder.Entity<Escala1>(entity =>
            {
                entity.ToTable("Escalas");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.Property(e => e.IdVuelo).HasColumnName("idVuelo");

                entity.Property(e => e.Tiempo).HasColumnName("tiempo");

                entity.HasOne(d => d.IdVueloNavigation)
                    .WithMany(p => p.Escala1s)
                    .HasForeignKey(d => d.IdVuelo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Escalas_Vuelo");
            });

            modelBuilder.Entity<Flotilla>(entity =>
            {
                entity.ToTable("Flotilla");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.Property(e => e.IdAerolinea).HasColumnName("idAerolinea");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.HasOne(d => d.IdAerolineaNavigation)
                    .WithMany(p => p.Flotillas)
                    .HasForeignKey(d => d.IdAerolinea)
                    .HasConstraintName("fk_id_Aero");
            });

            modelBuilder.Entity<Modulo>(entity =>
            {
                entity.ToTable("Modulo");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Idrol).HasColumnName("idrol");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.HasOne(d => d.IdrolNavigation)
                    .WithMany(p => p.Modulos)
                    .HasForeignKey(d => d.Idrol)
                    .HasConstraintName("FK_Modulo_Rol");
            });

            modelBuilder.Entity<Operacione>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdModulo).HasColumnName("idModulo");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.HasOne(d => d.IdModuloNavigation)
                    .WithMany(p => p.Operaciones)
                    .HasForeignKey(d => d.IdModulo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Operaciones_Modulo");
            });

            modelBuilder.Entity<Origen>(entity =>
            {
                entity.ToTable("Origen");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdAeropuerto).HasColumnName("idAeropuerto");

                entity.HasOne(d => d.IdAeropuertoNavigation)
                    .WithMany(p => p.Origens)
                    .HasForeignKey(d => d.IdAeropuerto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Origen_Aeropuerto");
            });

            modelBuilder.Entity<Pai>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Pasajero>(entity =>
            {
                entity.ToTable("PASAJEROS");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdAsiento).HasColumnName("idAsiento");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Pasaporte).HasColumnName("pasaporte");

                entity.HasOne(d => d.IdAsientoNavigation)
                    .WithMany(p => p.Pasajeros)
                    .HasForeignKey(d => d.IdAsiento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_id_pasajeros");
            });

            modelBuilder.Entity<Pasajeroreserva>(entity =>
            {
                entity.ToTable("PASAJERORESERVA");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Idpasajero).HasColumnName("IDPASAJERO");

                entity.Property(e => e.Idreserva).HasColumnName("IDRESERVA");

                entity.HasOne(d => d.IdpasajeroNavigation)
                    .WithMany(p => p.Pasajeroreservas)
                    .HasForeignKey(d => d.Idpasajero)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_id_PasajeroReserva");

                entity.HasOne(d => d.IdreservaNavigation)
                    .WithMany(p => p.Pasajeroreservas)
                    .HasForeignKey(d => d.Idreserva)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_id_PR");
            });

            modelBuilder.Entity<Reserva>(entity =>
            {
                entity.ToTable("RESERVA");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FechaReserva)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaReserva");

                entity.Property(e => e.IdAgencia).HasColumnName("idAgencia");

                entity.Property(e => e.IdAsiento).HasColumnName("idAsiento");

                entity.Property(e => e.IdPasajero).HasColumnName("idPasajero");

                entity.Property(e => e.IdVuelo).HasColumnName("idVuelo");

                entity.HasOne(d => d.IdAgenciaNavigation)
                    .WithMany(p => p.Reservas)
                    .HasForeignKey(d => d.IdAgencia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_id_Reserva");
            });

            modelBuilder.Entity<Rol>(entity =>
            {
                entity.ToTable("Rol");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<RolOperacion>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("RolOperacion");

                entity.Property(e => e.Idoperacion).HasColumnName("idoperacion");

                entity.Property(e => e.Idrol).HasColumnName("idrol");

                entity.HasOne(d => d.IdoperacionNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Idoperacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RolOperacion_Operaciones");

                entity.HasOne(d => d.IdrolNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Idrol)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RolOperacion_Rol");
            });

            modelBuilder.Entity<Rutum>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FechaAterrizaje)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaAterrizaje");

                entity.Property(e => e.FechaDespegue)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaDespegue");

                entity.Property(e => e.IdDestino).HasColumnName("idDestino");

                entity.Property(e => e.IdOrigen).HasColumnName("idOrigen");

                entity.HasOne(d => d.IdDestinoNavigation)
                    .WithMany(p => p.Ruta)
                    .HasForeignKey(d => d.IdDestino)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ruta_Destino");

                entity.HasOne(d => d.IdOrigenNavigation)
                    .WithMany(p => p.Ruta)
                    .HasForeignKey(d => d.IdOrigen)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ruta_Origen");
            });

            modelBuilder.Entity<Tarifa>(entity =>
            {
                entity.ToTable("Tarifa");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdAerolinea).HasColumnName("idAerolinea");

                entity.Property(e => e.Monto)
                    .HasColumnType("decimal(4, 2)")
                    .HasColumnName("monto");

                entity.HasOne(d => d.IdAerolineaNavigation)
                    .WithMany(p => p.Tarifas)
                    .HasForeignKey(d => d.IdAerolinea)
                    .HasConstraintName("fk_id");
            });

            modelBuilder.Entity<Tripulacion>(entity =>
            {
                entity.HasKey(e => e.IdTripulacion)
                    .HasName("PK__Tripulac__0AA20ADD07077ACC");

                entity.ToTable("Tripulacion");

                entity.Property(e => e.IdTripulacion).HasColumnName("id_tripulacion");

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.IdAvion).HasColumnName("id_avion");

                entity.Property(e => e.PrimerApellido)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("primer_apellido");

                entity.Property(e => e.PrimerNombre)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("primer_nombre");

                entity.Property(e => e.Puesto)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("puesto");

                entity.Property(e => e.SegundoApellido)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("segundo_apellido");

                entity.Property(e => e.SegundoNombre)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("segundo_nombre");

                entity.HasOne(d => d.IdAvionNavigation)
                    .WithMany(p => p.Tripulacions)
                    .HasForeignKey(d => d.IdAvion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_id_avion");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("Usuario");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("apellido");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.IdRol).HasColumnName("idRol");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .IsUnicode(false);

                entity.HasOne(d => d.IdRolNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdRol)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Usuario_Rol");
            });

            modelBuilder.Entity<Vuelo>(entity =>
            {
                entity.ToTable("Vuelo");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdAerolinea).HasColumnName("idAerolinea");

                entity.Property(e => e.Idruta).HasColumnName("idruta");

                entity.HasOne(d => d.IdAerolineaNavigation)
                    .WithMany(p => p.Vuelos)
                    .HasForeignKey(d => d.IdAerolinea)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Vuelo_aerolinea");

                entity.HasOne(d => d.IdrutaNavigation)
                    .WithMany(p => p.Vuelos)
                    .HasForeignKey(d => d.Idruta)
                    .HasConstraintName("FK_Vuelo_Ruta");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
