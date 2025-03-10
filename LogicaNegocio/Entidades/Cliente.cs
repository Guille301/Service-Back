using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LogicaNegocio.Entidades
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public byte[] FotoPerfil { get; set; }
        public string Email { get; set; }
        public int Celular { get; set; }
        public string Sexo { get; set; }
        public string Ciudad { get; set; }
        public string Barrio { get; set; }
        public DateTime FechaDeNacimiento { get; set; }

        // Relación con comentarios
        public List<ComentariosServicio> Comentarios { get; set; }

        // Relación con servicios contratados
        public List<ServicioContratado> ServiciosContratados { get; set; }

        public List<Mensajes> Mensajes { get; set; } = new List<Mensajes>();



        //Contraseña

        public string PasswordHash { get; private set; }
        public string Salt { get; private set; }



        public void SetPassword(string contrasena)
        {
            if (!ValidarContra(contrasena))
            {
                throw new Exception("La contraseña no cumple con los requisitos.");
            }

            Salt = GenerateSalt();
            PasswordHash = HashPassword(contrasena, Salt);
        }

        public bool VerifyPassword(string contrasena)
        {
            return PasswordHash == HashPassword(contrasena, Salt);
        }

        private string GenerateSalt()
        {
            byte[] saltBytes = new byte[16];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(saltBytes);
            }
            return Convert.ToBase64String(saltBytes);
        }

        private string HashPassword(string contrasena, string salt)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(contrasena + salt);
                byte[] hashBytes = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hashBytes);
            }
        }

        public static bool ValidarContra(string contrasena)
        {
            Regex regex = new Regex(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,15}$");
            return regex.IsMatch(contrasena);
        }





        public Cliente()
        {
            
        }


        public Cliente(string nombre, string email, int celular, string sexo, string ciudad, string barrio, string contrasena, DateTime fechaDeNacimiento, List<ComentariosServicio> comentarios, List<ServicioContratado> serviciosContratados, List<Mensajes> mensajes)
        {
            Nombre = nombre;
            Email = email;
            Celular = celular;
            Sexo = sexo;
            Ciudad = ciudad;
            Barrio = barrio;
            SetPassword(contrasena);
            FechaDeNacimiento = fechaDeNacimiento;
            Comentarios = comentarios;
            ServiciosContratados = serviciosContratados;
            Mensajes = mensajes;
        }

        public Cliente(string nombre, string email, int celular, string sexo, string ciudad, string barrio, string contrasena, DateTime fechaDeNacimiento)
        {
            Nombre = nombre;
            Email = email;
            Celular = celular;
            Sexo = sexo;
            Ciudad = ciudad;
            Barrio = barrio;
            SetPassword(contrasena);
            FechaDeNacimiento = fechaDeNacimiento;
        }

        public Cliente(int id, string nombre, string email, int celular, string sexo, string ciudad, string barrio, string contrasena, DateTime fechaDeNacimiento)
        {
            Id = id;
            Nombre = nombre;
            Email = email;
            Celular = celular;
            Sexo = sexo;
            Ciudad = ciudad;
            Barrio = barrio;
            SetPassword(contrasena);
            FechaDeNacimiento = fechaDeNacimiento;
        }



        
        
        
        
        //Validaciones
      


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
