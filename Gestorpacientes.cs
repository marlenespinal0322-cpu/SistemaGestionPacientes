namespace GestionPacientes
{
    public class GestorPacientes
    {
        private List<Pacientes> pacientes = new List<Pacientes>();

        public bool RegistrarPaciente(Pacientes paciente)
        {
            if (pacientes.Any(p => p.Id == paciente.Id))
            {
                return false;
            }

            pacientes.Add(paciente);
            return true;
        }

        public List<Pacientes> ObtenerTodos()
        {
            return pacientes;
        }

        public Pacientes BuscarPorId(string id)
        {
            return pacientes.FirstOrDefault(p => p.Id == id);
        }

        
        public List<Pacientes> BuscarPorNombre(string nombre)
        {
            return pacientes
                .Where(p => p.NombreCompleto
                .Contains(nombre, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        public bool ActualizarPaciente(string id, string nombre,
            int edad, string sexo, string diagnostico,
            DateTime fechaIngreso)
        {
            Pacientes paciente = BuscarPorId(id);

            if (paciente == null)
            {
                return false;
            }

            paciente.NombreCompleto = nombre;
            paciente.Edad = edad;
            paciente.Sexo = sexo;
            paciente.Diagnostico = diagnostico;
            paciente.FechaIngreso = fechaIngreso;

            return true;
        }

        public bool EliminarPaciente(string id)
        {
            Pacientes paciente = BuscarPorId(id);

            if (paciente == null)
            {
                return false;
            }

            pacientes.Remove(paciente);
            return true;
        }
    }
}
