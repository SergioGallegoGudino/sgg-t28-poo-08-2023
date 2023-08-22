using System;
using System.Runtime.CompilerServices;

namespace TA28
{

    public enum Materia
    {
        M,
        L,
        F
    }
    public class Persona
    {
        public enum Sexo
        {
            H,
            M
        }

        private String _Nombre;
        private int _Edad;
        private Sexo _Sexo;
        private Boolean _Disponible;

        public String nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

        public int edad
        {
            get { return _Edad; }
            set { _Edad = value;  }
        }

        public Sexo sexo
        {
            get { return _Sexo; }
            set { _Sexo = value; }
        }

        public Boolean disponible
        {
            get { return _Disponible; }
            set { _Disponible = value; }
        }

        public static Boolean esDisponible(int porcentaje)
        {
            Random random = new Random();
            int prob = random.Next(1, 101);

            if (prob >= porcentaje)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public Persona(String nombre, int edad, char sexo)
        {
            this.nombre = nombre;
            this.edad = edad;
            this.sexo = (Sexo)sexo;
            this.disponible = false;
        }

    }

    public class Estudiante : Persona
    {
        private int _Nota;

        public int nota
        {
            get { return _Nota; }
            set { _Nota = value; }
        }

        

        public Estudiante(String nombre, int edad, char sexo, int nota): base(nombre, edad, sexo)
        {
            this.nombre = nombre;
            this.edad = edad;
            this.sexo = (Sexo)sexo;
            this.nota = nota;
            this.disponible = esDisponible(50);
        }
    }

    public class Profesores : Persona
    {
        

        private Materia _Materia;

        public Materia materia
        {
            get { return _Materia; }
            set { _Materia = value; }
        }

        public Profesores(String nombre, int edad, char sexo, char materia) : base(nombre, edad, sexo)
        {
            this.nombre = nombre;
            this.edad = edad;
            this.sexo = (Sexo)sexo;
            this.materia = (Materia)materia;
            this.disponible = esDisponible(80);
        }
    }

    public class Aula
    {

        private int _Id;
        private Estudiante[] _Estudiantes;
        private Materia _Materia;
        private Profesores _Profesor;

        public int id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        public Estudiante[] estudiantes
        {
            get { return _Estudiantes; }
            set { _Estudiantes = value;}
        }

        public Materia materia
        {
            get { return _Materia; }
            set { _Materia = value; }
        }

        public Profesores profesor
        {
            get { return _Profesor; }
            set { _Profesor = value; }
        }

        public void darClase() {

            int aprobadosChicos = 0;
            int aprobadosChicas = 0;
            int contadorAlumnos = 0;

            for (int i = 0; i < this.estudiantes.Length; i++)
            {
                if (this.estudiantes[i].nota >= 5 && this.estudiantes[i].sexo == (Persona.Sexo)'H')
                {
                    aprobadosChicos++;
                } else if (this.estudiantes[i].nota >= 5 && this.estudiantes[i].sexo == (Persona.Sexo)'M')
                {
                    aprobadosChicas++;
                }

                if (this.estudiantes[i].disponible == true)
                {
                    contadorAlumnos++;
                }

            }

            if (
                this.profesor.disponible == true
                && this.profesor.materia == this.materia
                && contadorAlumnos >= (estudiantes.Length/2)
            ) 
            {
                Console.WriteLine("Se pueden dar clases!");
                Console.WriteLine("Número de alumnos aprobados: " + aprobadosChicos);
                Console.WriteLine("Número de alumnas aprobadas: " + aprobadosChicas);
            }
            else
            {
                Console.WriteLine("No se pueden dar clases");
            }
        
        }

        public Aula(int id, Estudiante[] estudiantes, char materia, Profesores profesor)
        {
            this.id = id;
            this.estudiantes = estudiantes;
            this.materia = (Materia)materia;
            this.profesor = profesor;
        }

    }

    public class Program
    {
        public static void Main(string[] args)
        {
            Estudiante e1 = new Estudiante("Estudiante 1", 15, 'H', 6);
            Estudiante e2 = new Estudiante("Estudiante 2", 14, 'M', 2);
            Estudiante e3 = new Estudiante("Estudiante 3", 15, 'H', 9);
            Estudiante e4 = new Estudiante("Estudiante 4", 14, 'H', 3);
            Estudiante e5 = new Estudiante("Estudiante 5", 15, 'H', 7);
            Estudiante e6 = new Estudiante("Estudiante 6", 14, 'M', 1);
            Estudiante e7 = new Estudiante("Estudiante 7", 15, 'M', 4);
            Estudiante e8 = new Estudiante("Estudiante 8", 14, 'H', 6);
            Estudiante e9 = new Estudiante("Estudiante 9", 15, 'H', 9);
            Estudiante e10 = new Estudiante("Estudiante 10", 14, 'M', 10);

            Estudiante[] array = new Estudiante[] {e1,e2,e3,e4,e5,e6,e7,e8,e9,e10};

            Profesores p1 = new Profesores("Profesor 1", 30, 'H', 'F');

            Aula a1 = new Aula(23, array, 'F', p1);

            a1.darClase();
        }
    }
}