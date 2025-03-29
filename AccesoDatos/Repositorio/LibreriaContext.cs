using LogicaNegocio.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Repositorio
{
    public class LibreriaContext : DbContext
    {
        public LibreriaContext(DbContextOptions<LibreriaContext> opciones) : base(opciones)
        {

        }

        public DbSet<Cliente> Cliente { get; set; }

        public DbSet<ComentariosPrestador> ComentariosPrestador { get; set; }

        public DbSet<ComentariosServicio> ComentariosServicio { get; set; }

        public DbSet<Mensajes> Mensajes { get; set; }

        public DbSet<Prestador> Prestador { get; set; }

        public DbSet<ServicioContratado> ServicioContratado { get; set; }

        public DbSet<Servicio> Servicio { get; set; }

        public DbSet<Solicitud> Solicitud { get; set; }

        public DbSet<ClienteAmigo> ClienteAmigo { get; set; }

        public DbSet<UsuarioCliente> UsuariosClientes { get; set; }
        public DbSet<UsuarioPrestador> UsuariosPrestadores { get; set; }






        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Amigos

            // Configuración de la relación muchos-a-muchos
            modelBuilder.Entity<ClienteAmigo>()
                .HasKey(ca => new { ca.ClienteId, ca.AmigoId }); 

            modelBuilder.Entity<ClienteAmigo>()
                .HasOne(ca => ca.Cliente)
                .WithMany(c => c.Amigos)
                .HasForeignKey(ca => ca.ClienteId)
                .OnDelete(DeleteBehavior.Restrict); 

            modelBuilder.Entity<ClienteAmigo>()
                .HasOne(ca => ca.Amigo)
                .WithMany()
                .HasForeignKey(ca => ca.AmigoId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ClienteAmigo>()
        .HasKey(ca => ca.Id);

            modelBuilder.Entity<ClienteAmigo>()
                .Property(ca => ca.Id)
                .ValueGeneratedOnAdd();






            //Solicitud

            modelBuilder.Entity<Solicitud>()
                .HasOne(s => s.cliente)
                .WithMany()  // Si Cliente tiene una lista de Solicitudes, aquí va .WithMany(c => c.Solicitudes)
                .HasForeignKey(s => s.IdCliente);

            modelBuilder.Entity<Solicitud>()
                .HasOne(s => s.servicio)
                .WithMany()  // Si Servicio tiene una lista de Solicitudes, aquí va .WithMany(s => s.Solicitudes)
                .HasForeignKey(s => s.IdServicio);
        }





    }
}
