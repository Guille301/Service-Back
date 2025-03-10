using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LogicaNegocio.Entidades
{
    public class Prestador
    {
        public int Id { get; set; }
        public byte[] FotoPerfil { get; set; }

        public string Nombre { get; set; }
        public string Email { get; set; }
        public int Celular { get; set; } 
        public string Sexo { get; set; }
        public string Ciudad { get; set; }
        public string Barrio { get; set; }
        public string Descripcion { get; set; }
        public byte[] ImagenesDeTrabajos { get; set; }
        public DateTime FechaDeNacimiento { get; set; }

        public List<Servicio> Servicios { get; set; } // Relación uno-a-muchos

        public List<ServicioContratado> Trabajos { get; set; } = new List<ServicioContratado>();

        // Relación con comentarios
        public List<ComentariosPrestador> Comentarios { get; set; }


        public List<Solicitud> Solicitudes { get; set; }

        public List<Mensajes> Mensajes { get; set; } = new List<Mensajes>();


        public string PasswordHash { get; private set; }
        public string Salt { get; private set; }

        public void SetPassword(string password)
        {
            if (!EsPasswordValida(password))
            {
                throw new ArgumentException("La contraseña debe tener entre 8 y 15 caracteres, incluir al menos una letra, un número y un carácter especial.");
            }

            Salt = GenerateSalt();
            PasswordHash = HashPassword(password, Salt);
        }

        public bool ValidatePassword(string password)
        {
            string hashAttempt = HashPassword(password, Salt);
            return hashAttempt == PasswordHash;
        }

        private string GenerateSalt()
        {
            byte[] saltBytes = new byte[16];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(saltBytes);
            }
            return Convert.ToBase64String(saltBytes);
        }

        private string HashPassword(string password, string salt)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] combinedBytes = Encoding.UTF8.GetBytes(password + salt);
                byte[] hashBytes = sha256.ComputeHash(combinedBytes);
                return Convert.ToBase64String(hashBytes);
            }
        }

        private bool EsPasswordValida(string password)
        {
            if (string.IsNullOrEmpty(password)) return false;

            string patron = @"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,15}$";
            return Regex.IsMatch(password, patron);
        }
    






        public Prestador()
        {
            
        }



        public Prestador(string nombre, string email, int celular, string sexo, string ciudad, string barrio, string descripcion, byte[] imagenesDeTrabajos, List<Servicio> servicios, List<ComentariosPrestador> comentarios, List<Mensajes> mensajes)
        {
            
            Nombre = nombre;
            Email = email;
            Celular = celular;
            Sexo = sexo;
            Ciudad = ciudad;
            Barrio = barrio;
            Descripcion = descripcion;
            ImagenesDeTrabajos = imagenesDeTrabajos;
            Servicios = servicios;
            Comentarios = comentarios;
            Mensajes = mensajes;
        }

        public Prestador(int id, string nombre, string email, int celular, string ciudad, string barrio, string descripcion)
        {
            Id = id;
            Nombre = nombre;
            Email = email;
            Celular = celular;
            Ciudad = ciudad;
            Barrio = barrio;
            Descripcion = descripcion;
        }

        public Prestador(byte[] fotoPerfil, string nombre, string email, int celular, string sexo, string ciudad, string barrio, string descripcion, byte[] imagenesDeTrabajos, DateTime fechaDeNacimiento, List<Servicio> servicios, List<ServicioContratado> trabajos, List<ComentariosPrestador> comentarios, List<Solicitud> solicitudes, List<Mensajes> mensajes, string passwordHash, string salt)
        {
            FotoPerfil = fotoPerfil;
            Nombre = nombre;
            Email = email;
            Celular = celular;
            Sexo = sexo;
            Ciudad = ciudad;
            Barrio = barrio;
            Descripcion = descripcion;
            ImagenesDeTrabajos = imagenesDeTrabajos;
            FechaDeNacimiento = fechaDeNacimiento;
            Servicios = servicios;
            Trabajos = trabajos;
            Comentarios = comentarios;
            Solicitudes = solicitudes;
            Mensajes = mensajes;
            PasswordHash = passwordHash;
            Salt = salt;
        }

        public bool ValidarNombre()
        {
            if (this.Nombre.Length >= 3 && this.Nombre.Length <= 25)
            {
                return true;
            }

            return false;
        }


        public bool ValidarMail()
        {
            if (string.IsNullOrEmpty(this.Email))
                return false;

            string patron = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(this.Email, patron);
        }









    }
}
