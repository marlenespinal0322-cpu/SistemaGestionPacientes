class Program
{
    static void Main(string[] args)
    {
        GestorPacientes gestor = new GestorPacientes();
        string opcion = "";

        while (opcion != "6")
        {
            Console.Clear();

            Console.WriteLine("===== SISTEMA DE GESTIÓN DE PACIENTES =====");
        Console.WriteLine("1. Registrar nuevo paciente");
        Console.WriteLine("2. Listar todos los pacientes");
        Console.WriteLine("3. Buscar paciente por ID o nombre");
        Console.WriteLine("4. Actualizar datos de un paciente");
        Console.WriteLine("5. Eliminar un paciente");
        Console.WriteLine("6. Salir del sistema");

        Console.Write("Seleccione una opción: ");
            opcion = Console.ReadLine();
            

            switch (opcion)
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine("===== REGISTRAR NUEVO PACIENTE =====");

                    Console.Write("ID: ");
                    string id = Console.ReadLine();

                    Console.Write("Nombre completo: ");
                    string nombre = Console.ReadLine();

                    Console.Write("Edad: ");
                    int edad = int.Parse(Console.ReadLine());

                    Console.Write("Sexo: ");
                    string sexo = Console.ReadLine();

                    Console.Write("Diagnóstico: ");
                    string diagnostico = Console.ReadLine();

                    Console.Write("Fecha de ingreso (dd/mm/aaaa): ");
                    DateTime fechaIngreso = DateTime.Parse(Console.ReadLine()!);

                    Pacientes paciente = new Pacientes(
                        id,
                        nombre,
                        edad,
                        sexo,
                        diagnostico,
                        fechaIngreso
                    );

                    bool registrado = gestor.RegistrarPaciente(paciente);

                    if (registrado)
                    {
                        Console.WriteLine("\nPaciente registrado correctamente.");
                    }
                    else
                    {
                        Console.WriteLine("\nYa existe un paciente con ese ID.");
                    }

                    Console.WriteLine("\nPresione ENTER para continuar...");
                    Console.WriteLine("VOLVIENDO AL MENU...");
                    Console.ReadLine();

                    break;

                case "2":
                    Console.Clear();
                    Console.WriteLine("===== LISTA DE PACIENTES =====");

                    List<Pacientes> lista = gestor.ObtenerTodos();

                    if (lista.Count == 0)
                    {
                        Console.WriteLine("No hay pacientes registrados.");
                    }
                    else
                    {
                        foreach (Pacientes p in lista)
                        {
                            Console.WriteLine("------------------------------");
                            Console.WriteLine("ID: " + p.Id);
                            Console.WriteLine("Nombre: " + p.NombreCompleto);
                            Console.WriteLine("Edad: " + p.Edad);
                            Console.WriteLine("Sexo: " + p.Sexo);
                            Console.WriteLine("Diagnóstico: " + p.Diagnostico);
                            Console.WriteLine("Fecha de ingreso: " + p.FechaIngreso.ToString("dd/MM/yyyy"));
                        }
                    }

                    Console.WriteLine("\nPresione ENTER para continuar...");
                    Console.ReadLine();
                    break;


                case "3":
                    Console.Clear();
                    Console.WriteLine("===== BUSCAR PACIENTE =====");
                    Console.WriteLine("1. Buscar por ID");
                    Console.WriteLine("2. Buscar por nombre");

                    Console.Write("Seleccione una opción: ");
                    string tipoBusqueda = Console.ReadLine();

                    if (tipoBusqueda == "1")
                    {
                        Console.Write("Ingrese el ID del paciente: ");
                        string idBuscar = Console.ReadLine();

                        Pacientes pacienteEncontrado = gestor.BuscarPorId(idBuscar);

                        if (pacienteEncontrado != null)
                        {
                            Console.WriteLine("\nPaciente encontrado:");
                            Console.WriteLine("------------------------------");
                            Console.WriteLine("ID: " + pacienteEncontrado.Id);
                            Console.WriteLine("Nombre: " + pacienteEncontrado.NombreCompleto);
                            Console.WriteLine("Edad: " + pacienteEncontrado.Edad);
                            Console.WriteLine("Sexo: " + pacienteEncontrado.Sexo);
                            Console.WriteLine("Diagnóstico: " + pacienteEncontrado.Diagnostico);
                            Console.WriteLine("Fecha de ingreso: " +
                                pacienteEncontrado.FechaIngreso.ToString("dd/MM/yyyy"));
                        }
                        else
                        {
                            Console.WriteLine("\nNo se encontró un paciente con ese ID.");
                        }
                    }
                    else if (tipoBusqueda == "2")
                    {
                        Console.Write("Ingrese el nombre del paciente: ");
                        string nombreBuscar = Console.ReadLine();

                        List<Pacientes> resultados = gestor.BuscarPorNombre(nombreBuscar);

                        if (resultados.Count > 0)
                        {
                            Console.WriteLine("\nPacientes encontrados:");

                            foreach (Pacientes p in resultados)
                            {
                                Console.WriteLine("------------------------------");
                                Console.WriteLine("ID: " + p.Id);
                                Console.WriteLine("Nombre: " + p.NombreCompleto);
                                Console.WriteLine("Edad: " + p.Edad);
                                Console.WriteLine("Sexo: " + p.Sexo);
                                Console.WriteLine("Diagnóstico: " + p.Diagnostico);
                                Console.WriteLine("Fecha de ingreso: " +
                                    p.FechaIngreso.ToString("dd/MM/yyyy"));
                            }
                        }
                        else
                        {
                            Console.WriteLine("\nNo se encontraron pacientes con ese nombre.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nOpción no válida.");
                    }

                    Console.WriteLine("\nPresione ENTER para continuar...");
                    Console.ReadLine();
                    break;
                    

                case "4":
                    Console.Clear();
                    Console.WriteLine("===== ACTUALIZAR PACIENTE =====");

                    Console.Write("Ingrese el ID del paciente que desea actualizar: ");
                    string idActualizar = Console.ReadLine();

                    Pacientes pacienteActualizar = gestor.BuscarPorId(idActualizar);

                    if (pacienteActualizar == null)
                    {
                        Console.WriteLine("\nNo se encontró un paciente con ese ID.");
                    }
                    else
                    {
                        Console.WriteLine("\nIngrese los nuevos datos:");

                        Console.Write("Nombre completo: ");
                        string nuevoNombre = Console.ReadLine();

                        Console.Write("Edad: ");
                        int nuevaEdad = int.Parse(Console.ReadLine());

                        Console.Write("Sexo: ");
                        string nuevoSexo = Console.ReadLine();

                        Console.Write("Diagnóstico: ");
                        string nuevoDiagnostico = Console.ReadLine();

                        Console.Write("Fecha de ingreso (dd/mm/aaaa): ");
                        DateTime nuevaFecha = DateTime.Parse(Console.ReadLine());

                        bool actualizado = gestor.ActualizarPaciente(
                            idActualizar,
                            nuevoNombre,
                            nuevaEdad,
                            nuevoSexo,
                            nuevoDiagnostico,
                            nuevaFecha
                        );

                        if (actualizado)
                        {
                            Console.WriteLine("\nPaciente actualizado correctamente.");
                        }
                        else
                        {
                            Console.WriteLine("\nNo se pudo actualizar el paciente.");
                        }
                    }

                    Console.WriteLine("\nPresione ENTER para continuar...");
                    Console.ReadLine();
                    break;

                case "5":
                    Console.Clear();
                    Console.WriteLine("===== ELIMINAR PACIENTE =====");

                    Console.Write("Ingrese el ID del paciente que desea eliminar: ");
                    string idEliminar = Console.ReadLine()!;

                    Pacientes pacienteEliminar = gestor.BuscarPorId(idEliminar);

                    if (pacienteEliminar == null)
                    {
                        Console.WriteLine("\nNo se encontró un paciente con ese ID.");
                    }
                    else
                    {
                        Console.WriteLine("\nPaciente encontrado:");
                        Console.WriteLine("Nombre: " + pacienteEliminar.NombreCompleto);
                        Console.WriteLine("Edad: " + pacienteEliminar.Edad);
                        Console.WriteLine("Diagnóstico: " + pacienteEliminar.Diagnostico);

                        Console.Write("\n¿Está seguro de que desea eliminarlo? (S/N): ");
                        string confirmar = Console.ReadLine()!;

                        if (confirmar.ToUpper() == "S")
                        {
                            bool eliminado = gestor.EliminarPaciente(idEliminar);

                            if (eliminado)
                            {
                                Console.WriteLine("\nPaciente eliminado correctamente.");
                            }
                            else
                            {
                                Console.WriteLine("\nNo se pudo eliminar el paciente.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("\nEliminación cancelada.");
                        }
                    }

                    Console.WriteLine("\nPresione ENTER para continuar...");
                    Console.ReadLine();
                    break;

                case "6":
                    Console.WriteLine("\nSaliendo del sistema...");
                    break;


                default:
                    Console.WriteLine("\nOpción no válida.");
                    Console.WriteLine("Presione ENTER para continuar...");
                    Console.ReadLine();
                    break;

            }

        }

    }
}
