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


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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
