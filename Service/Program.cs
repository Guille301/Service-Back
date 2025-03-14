
using AccesoDatos.Repositorio;
using LogicaAplicacion.ImplementacionCU.Amigos;
using LogicaAplicacion.ImplementacionCU.Buscador;
using LogicaAplicacion.ImplementacionCU.Cliente;
using LogicaAplicacion.ImplementacionCU.Comentarios.ComentariosPrestador;
using LogicaAplicacion.ImplementacionCU.Comentarios.ComentariosServicios;
using LogicaAplicacion.ImplementacionCU.Prestador;
using LogicaAplicacion.ImplementacionCU.Servicio;
using LogicaAplicacion.ImplementacionCU.Servicio.ListadoInicioFijo;
using LogicaAplicacion.ImplementacionCU.ServicioContratado;
using LogicaAplicacion.ImplementacionCU.Solicitud;
using LogicaAplicacion.InterfaceCU.AmigosInterface;
using LogicaAplicacion.InterfaceCU.BuscadorInterface;
using LogicaAplicacion.InterfaceCU.Cliente;
using LogicaAplicacion.InterfaceCU.Comentarios.ComentariosPrestador;
using LogicaAplicacion.InterfaceCU.Comentarios.ComentariosServicios;
using LogicaAplicacion.InterfaceCU.Prestador;
using LogicaAplicacion.InterfaceCU.Servicio;
using LogicaAplicacion.InterfaceCU.Servicio.IListadoInicioFijo;
using LogicaAplicacion.InterfaceCU.ServicioContratado;
using LogicaAplicacion.InterfaceCU.Solicitud;
using LogicaNegocio.InterfacesRepositorios;
using Microsoft.EntityFrameworkCore;

namespace Service
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            builder.Services.AddDbContext<LibreriaContext>(options =>
               options.UseSqlServer(builder.Configuration.GetConnectionString("ConexionService")));


            /*Inyeccion de dependencias*/


            //Repositorios
            builder.Services.AddScoped<IRepositorioCliente, RepositorioClienteEF>();
            builder.Services.AddScoped<IRepositorioPrestador, RepositorioPrestadorEF>();
            builder.Services.AddScoped<IRepositorioServicio, RepositorioServicioEF>();
            builder.Services.AddScoped<IRepositorioServicioContratado, RepositorioServicioContratadoEF>();
            builder.Services.AddScoped<IRepositorioComentarioPrestador, RepositorioComentarioPrestadorEF>();
            builder.Services.AddScoped<IRepositorioComentarioServicio, RepositorioComentarioServicioEF>();
            builder.Services.AddScoped<IRepositorioSolicitud, RepositorioSolicitudEF>();
            builder.Services.AddScoped<IRepositorioClienteAmigos, RepositorioClienteAmigosEF>();



            /*Casos de uso*/

            //Cliente
            builder.Services.AddScoped<IAltaCliente, AltaCliente>();
            builder.Services.AddScoped<IListarClienteBuscado, ListarClienteBuscador>();
            builder.Services.AddScoped<IEditarCliente, EditarCliente>();
            builder.Services.AddScoped<IEliminarCliente, EliminarCliente>();
            builder.Services.AddScoped<IPerfilCliente, PerfilCliente>();





            //Prestador
            builder.Services.AddScoped<IAltaPrestador, AltaPrestador>();
            builder.Services.AddScoped<IListarPrestadorBuscador, ListarPrestadorBuscador>();
            builder.Services.AddScoped<IEditarPrestador, EditarPrestador>();
            builder.Services.AddScoped<IEliminarPrestador, EliminarPrestador>();
            builder.Services.AddScoped<IPerfilPrestador, PerfilPrestador>();



            /**** Servicios ****/
            builder.Services.AddScoped<IAltaServicio, AltaServicio>();
            builder.Services.AddScoped<IEditarServicio, EditarServicio>();
            builder.Services.AddScoped<IEliminarServicio, EliminarServicio>();
            builder.Services.AddScoped<IFiltrarServicio, FiltrarServicio>();
            builder.Services.AddScoped<IListarServicioCompleto, ListarServicioCompleto>();


            //Servicios fijos
            builder.Services.AddScoped<IListarBelleza, ListarBelleza>();
            builder.Services.AddScoped<IListarLegales, ListarLegales>();
            builder.Services.AddScoped<IListarReparaciones, ListarReparaciones>();




            //Servicio contratado
            builder.Services.AddScoped<IListarSerContratadoPrestador, ListarServicioContratadoPrestador>();
            builder.Services.AddScoped<IListarSerContratadoCliente, ListarServicioContratadoCliente>();
            builder.Services.AddScoped<IConfirmarRealizacion, ConfirmarRealizacion>();


            //Buscador 
            builder.Services.AddScoped<IBuscador, Buscador>();


            /*Comentarios*/
            //Comentarios prestador
            builder.Services.AddScoped<IAltaComentarioPrestador, AltaComentariosPrestador>();
            builder.Services.AddScoped<IEditarComentariosPrestador, EditarComentariosPrestador>();
            builder.Services.AddScoped<IEliminarComentarioPrestador, EliminarComentarioPrestador>();


            //Comentarios servicios
            builder.Services.AddScoped<IAltaComentarioServicios, AltaComentariosServicios>();
            builder.Services.AddScoped<IEditarComentariosServicio, EditarComentariosServicios>();
            builder.Services.AddScoped<IEliminarComentarioServicio, EliminarComentarioServicios>();


            //Solicitud
            builder.Services.AddScoped<IAltaSolicitud,AltaSolicitud>();
            builder.Services.AddScoped<IEliminarSolicitud, EliminarSolicitud>();
            builder.Services.AddScoped<IListarSolicitudes, ListarSolicitudes>();
            builder.Services.AddScoped<IAprobarSolicitud, AprobarSolicitud>();



            //Amigos
            builder.Services.AddScoped<IAgregarAmigos, AgregarAmigos>();
            builder.Services.AddScoped<IEliminarAmigos, EliminarAmigos>();







            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
