using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Repositorio
{
    public class RepositorioClienteEF : IRepositorioCliente
    {

        private LibreriaContext _db;
        public RepositorioClienteEF(LibreriaContext db)
        {
            _db = db;
        }

        //Alta
        public void Add(Cliente cliente)
        {
            using var transaction = _db.Database.BeginTransaction();
            try
            {
                // 1. Guardar cliente
                _db.Cliente.Add(cliente);
                _db.SaveChanges(); // Para obtener el ID

                // 2. Crear y guardar usuario
                var usuarioCliente = new UsuarioCliente
                {
                    Email = cliente.Email,
                    PasswordHash = cliente.PasswordHash,
                    FechaCreacion = DateTime.UtcNow,
                    ClienteId = cliente.Id
                };

                _db.UsuariosClientes.Add(usuarioCliente);
                _db.SaveChanges();

                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        //Find by email
        public Cliente FindByEmail(string email)
        {
            try
            {
                var usuario = _db.Cliente.Where(u => u.Email == email).FirstOrDefault();
                return usuario;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los clientes", ex);
            }
        }



        //Find All
        public IEnumerable<Cliente> FindAll()
        {
            try
            {
                return _db.Cliente.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los clientes", ex);
            }
        }

        //Update
        public void Update(Cliente objeto)
        {
            var cliOriginal = _db.Cliente.Find(objeto.Id);
            try
            {
                cliOriginal.Nombre = objeto.Nombre;
                cliOriginal.Email = objeto.Email;
                cliOriginal.Celular = objeto.Celular;
                cliOriginal.Sexo = objeto.Sexo;
                cliOriginal.Ciudad = objeto.Ciudad;
                cliOriginal.Barrio = objeto.Barrio;
                cliOriginal.FechaDeNacimiento = objeto.FechaDeNacimiento;


                // Actualizar la contraseña solo si se proporciona una nueva
                if (!string.IsNullOrEmpty(objeto.PasswordHash))
                {
                    cliOriginal.SetPassword(objeto.PasswordHash);
                }


                _db.Cliente.Update(cliOriginal);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception("Error al obtener los clientes", ex);
            }
        }






        //Delete
        public void Delete(int id)
        {
            var disciplina = _db.Cliente.Find(id);

            if (disciplina != null)
            {
                _db.Cliente.Remove(disciplina);  // Elimina la disciplina del DbContext
                _db.SaveChanges();  // Guardar cambios en la base de datos
            }
            else
            {
                throw new Exception("cliente no encontrado");
            }
        }



        //Buscador de clientes
        public IEnumerable<Cliente> BuscarClientes(string critero)
        {
            try
            {
                return _db.Cliente
                         .Where(c => c.Nombre.Contains(critero))
                         .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar clientes", ex);
            }
        }



        // Voy a usar esto para mostrar el perfil
        public Cliente FindById(int id)
        {
            try
            {
                var usuario = _db.Cliente.Where(u => u.Id == id).FirstOrDefault();
                return usuario;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los clientes", ex);
            }
        }






        



       

      
    }
}
