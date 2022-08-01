using System.Collections;
using System.Security.Cryptography.X509Certificates;

namespace PerformanceReview01082022
{
    internal class Program
    {
        public class Persona
        {
            public string Name { get; set; }
            public string Email { get; set; }
            public DateTime Birthday { get; set; }

            public Persona (string name, string email, DateTime birthday)
            {
                Name = name;
                Email = email;
                Birthday = birthday;
            }
        }

        static void Main(string[] args)
        {
            // 1. Lambdas and delegates
            // Delegado que reciba dos numeros y retorne la suma
            Func<int, int, int> add = (x, y) => x + y;
            int addResult = add(5, 5);
            Console.WriteLine($"El resultado de la suma es: {addResult}\n");

            // Delegado que reciba dos numeros y retorne la resta
            Func<int, int, int> subtract = (x, y) => x - y;
            Console.WriteLine($"El resultado de la resta es: {subtract.Invoke(10, 5)}\n");

            // Delegado que arroje una excepcion de tipo DivideByZero

            Action dividedByZero = () => throw new DivideByZeroException();

            // Delegado que recive dos numeros y el action anterior como parametro, de tal forma que que retorne la division o la excepcion
            // TODO agregar el delegado para la excepcion
            Func<float, float, float> getDivision = (x, y) => x / y;
            Console.WriteLine($"El resultado de la divison es: {getDivision.Invoke(10,2)}\n");

            // 2. LINQ
            // Crear una clase Persona con las propiedasdes de Name, Email y Birthday, e inserta 6 personas
            List<Persona> listaPersonas = new List<Persona>()
            {
                new Persona("Octavio", "octavio@correo.com", new DateTime(1998, 01, 01)),
                new Persona("Aram", "aram@correo.com", new DateTime(1997, 07, 13)),
                new Persona("Jazmin", "jaz@correo.com", new DateTime(1999, 03, 17)),
                new Persona("Ximena", "ximena@correo.com", new DateTime(1994, 05, 25)),
                new Persona("Rodrigo", "rodrigo@correo.com", new DateTime(1992, 05, 16)),
                new Persona("Juan", "juan@correo.com", new DateTime(2000, 02, 22))
            };

            // Nueva lista que tome los correos de las personas
            List<string> listPersonasCorreos = listaPersonas.Select(persona => persona.Email).ToList();
            foreach (var correos in listPersonasCorreos)
            {
                Console.WriteLine($"Correo {correos}");
            }

            // Filtrar la lista de personas por fecha de nacimiento a una fecha definida y retorne el 1ro de la lista
            var Date = new DateTime(2000, 01, 01);
            var personasFecha = listaPersonas.Where(p => p.Birthday <= Date).First();
            Console.WriteLine($"\nLa primer persona antes de esa fecha es: {personasFecha.Name}\n");

            Console.ReadLine();
        }
    }
}