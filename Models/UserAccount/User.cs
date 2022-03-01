using System;

namespace MinerdDocApi.Models.UserAccount
{
    public class User
    {
        public int Id            { get; set; }
        public string Nombre     {get;set;}
        public string Apellido   {get;set;}
        public string Cedula     {get;set;}
        public string Correo     {get;set;}
        public string Contraseña {get;set;}
        public DateTime FechaNac {get;set;}
        public string RNE        { get; set; }
    }
}
