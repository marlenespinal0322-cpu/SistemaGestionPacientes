using GestionPacientes;
using System;
using System.Security.Cryptography.X509Certificates;
namespace GestionPacientes
{
    public class Pacientes
    {
        public string Id { get; set; }
        public string NombreCompleto { get; set; }
        public int Edad { get; set; }
        public string Sexo { get; set; }
        public string Diagnostico { get; set; }
        public DateTime FechaIngreso { get; set; }

        public Pacientes (string id, string NombreCompleto, int edad, string sexo, string diagnostico,
            DateTime fechaIngreso)
        {
            Id = id;
            this.NombreCompleto = NombreCompleto;
            Edad = edad;
            Sexo = sexo;
            Diagnostico = diagnostico;
            FechaIngreso = fechaIngreso;

        }
    }
}

