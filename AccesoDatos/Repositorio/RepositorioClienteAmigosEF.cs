using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Repositorio
{
    public class RepositorioClienteAmigosEF : IRepositorioClienteAmigos
    {

        private LibreriaContext _db;
        public RepositorioClienteAmigosEF(LibreriaContext db)
        {
            _db = db;
        }



        // Método público para agregar una relación de amistad bidireccional
        public void AddAmistadBidireccional(int clienteId, int amigoId)
        {
            try
            {
                // Validar que no se agregue a sí mismo como amigo
                if (clienteId == amigoId)
                {
                    throw new ArgumentException("Un cliente no puede agregarse a sí mismo como amigo.");
                }

                // Crear las relaciones bidireccionales
                var amistad1 = new ClienteAmigo { ClienteId = clienteId, AmigoId = amigoId };
                var amistad2 = new ClienteAmigo { ClienteId = amigoId, AmigoId = clienteId };

                // Agregar las relaciones al contexto
                Add(amistad1);
                Add(amistad2);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar la amistad bidireccional", ex);
            }
        }




        //Alta de amigo
        public void Add(ClienteAmigo objeto)
        {
            try
            {


                _db.ClienteAmigo.Add(objeto);
                _db.SaveChanges();



            }
            catch (Exception ex)
            {

                throw new Exception("Error al agregar el amigo", ex);

            }
        }


        //Borrar amigo
        public void Delete(int id)
        {
            var cli = _db.ClienteAmigo.Find(id);

            if (cli != null)
            {
                _db.ClienteAmigo.Remove(cli);  
                _db.SaveChanges();  
            }
            else
            {
                throw new Exception("amigo no encontrado");
            }
        }


        //Mostrar los amigos del cliente
        public IEnumerable<ClienteAmigo> ListarAmigosPropios(int clienteId)
        {
            try
            {
                var amigos = _db.ClienteAmigo
          .Where(ca => ca.ClienteId == clienteId)
          .ToList();

                return amigos;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los amigos", ex);
            }
        }



        //Listar amigos recomendados
        public IEnumerable<ClienteAmigo> ListarAmigosRecomendados(int clienteId)
        {
            try
            {
                var amigosDirectos = _db.ClienteAmigo
                    .Where(ca => ca.ClienteId == clienteId)
                    .Select(ca => ca.AmigoId)
                    .ToList();

                var amigosDeAmigos = _db.ClienteAmigo
                    .Where(ca => amigosDirectos.Contains(ca.ClienteId) && ca.AmigoId != clienteId && !amigosDirectos.Contains(ca.AmigoId))
                    .Select(ca => new ClienteAmigo
                    {
                        ClienteId = clienteId,   
                        AmigoId = ca.AmigoId,    
                        Amigo = ca.Amigo         
                    })
                    .Distinct()
                    .ToList();

                return amigosDeAmigos;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los amigos recomendados", ex);
            }
        }







        public IEnumerable<ClienteAmigo> FindAll()
        {
            throw new NotImplementedException();
        }

    

        public ClienteAmigo FindById(int id)
        {
            throw new NotImplementedException();
        }

      

        public void Update(ClienteAmigo objeto)
        {
            throw new NotImplementedException();
        }

      
    }
}
