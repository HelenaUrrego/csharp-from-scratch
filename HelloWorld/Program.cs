using System;

namespace HelloWorld
{                                //como se llama el proyecto.el nombre de la carpeta donde esta
    class Program
    {
        static void Main()
        {
            // Variables para almacenar la entrada del usuario
            string nameInput;
            string birthdayInput;

            // Mensaje de bienvenida
            Console.WriteLine("Hola, bienvenido al calculador de años");

            // Solicitar el nombre del usuario
            Console.WriteLine("Escribe tu nombre: ");
            nameInput = Console.ReadLine();
            Console.WriteLine($"Un gusto conocerte {nameInput}");

            // Solicitar la fecha de nacimiento
            Console.WriteLine("Escribe tu fecha de nacimiento en formato yyyy-MM-dd: ");
            birthdayInput = Console.ReadLine();

            // Intentar convertir la fecha
            bool isDateValid = DateOnly.TryParse(birthdayInput, out DateOnly dateConverted);

            // Verificar si la conversión fue exitosa
            if (isDateValid)
            {
                var person = new Person
                {
                    Name = nameInput,
                    Birthday = dateConverted,
                    Age = DateTime.Now.Year - dateConverted.Year
                };

                // Ajustar la edad si la fecha de cumpleaños no ha ocurrido aún en el año actual
                if (DateTime.Now.Date < dateConverted.ToDateTime(new TimeOnly()))
                {
                    person.Age--;
                }

                Console.WriteLine($"Tu nombre: {person.Name}");
                Console.WriteLine($"Tu fecha de nacimiento: {person.Birthday}");
                Console.WriteLine($"Tu edad es: {person.Age} años");
            }
            else
            {
                Console.WriteLine($"La fecha de nacimiento es inválida, usted nos envió este dato erróneo: {birthdayInput}");
            }

            Console.ReadLine();
        }
    }

    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public DateOnly Birthday { get; set; }
    }
}