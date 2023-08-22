using System;
using System.Linq;
namespace TA28
{
    public class Cine
    {
        private Pelicula _Pelicula;
        private double _Precio;
        private Asientos[] _Asientos;

        public Pelicula pelicula
        {
            get { return _Pelicula; }
            set { _Pelicula = value; }
        }

        public double precio
        {
            get { return _Precio; }
            set { _Precio = value; }
        }

        public Asientos[] asientos
        {
            get { return _Asientos; }
            set { _Asientos = value; }
        }

        public Asientos[] prepararAsientos()
        {
            Asientos[] asientos = new Asientos[72];
            String[] letras = { "A", "B", "C", "D", "E", "F", "G", "H", "I" };

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Asientos asiento = new Asientos(i, letras[j]);
                    asientos[i * 9 + j] = asiento;
                }
            }

            return asientos;
        }

        public Cine(Pelicula pelicula, double precio)
        {
            this.pelicula = pelicula;
            this.precio = precio;
            this.asientos = prepararAsientos();
        }
    }

    public class Asientos
    {
        private int _Fila;
        private String _Columna;
        private Boolean _Ocupado;
        private Espectador _Espectador;

        public int fila
        {
            get { return _Fila; }
            set { _Fila = value; }
        }

        public String columna
        {
            get { return _Columna; } 
            set { _Columna = value; }
        }

        public Boolean ocupado
        {
            get { return _Ocupado;}
            set { _Ocupado = value; }
        }

        public Espectador espectador
        {
            get { return _Espectador; }
            set { _Espectador = value; }
        }

        public Asientos(int fila, String columna)
        {
            this.fila = fila;
            this.columna = columna;
            this.ocupado = false;
        }
    }

    public class Pelicula
    {
        private String _Titulo;
        private int _Duracion;
        private int _EdadMinima;
        private String _Director;

        public String titulo
        {
            get { return _Titulo; }
            set { _Titulo = value; }
        }

        public int duracion
        {
            get { return _Duracion; }
            set { _Duracion = value; }
        }

        public int edadMinima
        {
            get { return _EdadMinima; }
            set { _EdadMinima = value;}
        }

        public String director
        {
            get { return _Director; }
            set { _Director = value; }
        }

        public Pelicula(String titulo,int duracion, int edadMinima, String director)
        {
            this.titulo = titulo;
            this.duracion = duracion;
            this.edadMinima = edadMinima;
            this.director = director;
        }

    }

    public class Espectador
    {
        private String _Nombre;
        private int _Edad;
        private double _Dinero;

        public void asignarAsiento(Cine c, Espectador e)
        {
            if (e.edad >= c.pelicula.edadMinima && e.dinero >= c.precio)
            {
                Random random = new Random();

                while (true)
                {
                    int indiceAsiento = random.Next(c.asientos.Length);

                    Asientos asientoEspectador = c.asientos[indiceAsiento];

                    if (!asientoEspectador.ocupado)
                    {
                        asientoEspectador.ocupado = true;
                        asientoEspectador.espectador = e;
                        Console.WriteLine($"{e.nombre} ha sido asignado al asiento {asientoEspectador.fila}{asientoEspectador.columna}");
                        break;
                    }
                }
            }
            else
            {
                Console.WriteLine($"{e.nombre} no cumple los requisitos para acceder al cine.");
            }
        }

        public String nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

        public int edad
        {
            get { return _Edad; }
            set { _Edad = value; }
        }

        public double dinero
        {
            get { return _Dinero; }
            set { _Dinero = value; }
        }

        public Espectador(String nombre, int edad, double dinero)
        {
            this.nombre = nombre;
            this.edad = edad;
            this.dinero = dinero;
        }
    }

    public class Program
    {
        public static void Main(String[] args)
        {
            Pelicula p1 = new Pelicula("Pelicula 1", 120, 10, "Director 1");
            Cine c1 = new Cine(p1, 5);

            Espectador e1 = new Espectador("Espectador 1", 10, 5);
            Espectador e2 = new Espectador("Espectador 2", 9, 5);
            Espectador e3 = new Espectador("Espectador 3", 15, 1);
            Espectador e4 = new Espectador("Espectador 4", 12, 8);
            Espectador e5 = new Espectador("Espectador 5", 5, 0);

            e1.asignarAsiento(c1, e1);
            e2.asignarAsiento(c1, e2);
            e3.asignarAsiento(c1, e3);
            e4.asignarAsiento(c1, e4);
            e5.asignarAsiento(c1, e5);

        }
    }


}