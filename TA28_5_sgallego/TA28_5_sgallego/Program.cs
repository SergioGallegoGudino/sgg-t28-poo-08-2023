using System;
using System.Reflection.Metadata;

namespace TA28
{
    public class Serie : Entregable
    {
        private String _Titulo;
        private int _Temporadas;
        private Boolean _Entregado;
        private String _Genero;
        private String _Creador;

        public String titulo
        {
            get { return _Titulo; }
            set { _Titulo = value; }
        }

        public int temporadas
        {
            get { return _Temporadas; }
            set { _Temporadas = value; }
        }

        public Boolean entregado
        {
            get { return _Entregado; }
            set { _Entregado = value; }
        }

        public String genero
        {
            get { return _Genero; }
            set { _Genero = value; }
        }

        public String creador
        {
            get { return _Creador; }
            set { _Creador = value; }
        }


        public override string ToString()
        {
            return $"Titulo: {this.titulo}, Temporadas: {this.temporadas}, Entregado: {this.entregado}, Genero: {this.genero}, Creador: {this.creador}";
        }

        public void Entregar()
        {
            this.entregado = true;
        }

        public void Devolver()
        {
            this.entregado = false;
        }

        public bool IsEntregado()
        {
            return this.entregado;
        }

        public int CompareTo(object a)
        {
            if (a is Serie otraSerie)
            {
                return this.temporadas.CompareTo(otraSerie.temporadas);
            }
            else if (a is Videojuegos videojuego)
            {
                return this.temporadas.CompareTo(videojuego.horas);
            }
            else
            {
                throw new ArgumentException("El objeto proporcionado no es de tipo Serie ni Videojuego.");
            }
        }
        public Serie()
        {
            this.titulo = "";
            this.temporadas = 3;
            this.entregado = false;
            this.genero = "";
            this.creador = "";
        }

        public Serie(String titulo, String creador)
        {
            this.titulo = titulo;
            this.temporadas = 3;
            this.entregado = false;
            this.genero = "";
            this.creador = creador;
        }

        public Serie(String titulo, int temporadas, String genero, String creador)
        {
            this.titulo = titulo;
            this.temporadas = 3;
            this.entregado = false;
            this.genero = genero;
            this.creador = creador;
        }
    }

    public class Videojuegos : Entregable
    {
        private String _Titulo;
        private int _Horas;
        private Boolean _Entregado;
        private String _Genero;
        private String _Compania;

        public String titulo
        {
            get { return _Titulo; }
            set { _Titulo = value; }
        }

        public int horas
        {
            get { return _Horas; }
            set { _Horas = value; }
        }

        public Boolean entregado
        {
            get { return _Entregado; }
            set { _Entregado = value; }
        }

        public String genero
        {
            get { return _Genero; }
            set { _Genero = value; }
        }

        public String compania
        {
            get { return _Compania; }
            set { _Compania = value; }
        }

        public void Entregar()
        {
            this.entregado = true;
        }

        public void Devolver()
        {
            this.entregado = false;
        }

        public bool IsEntregado()
        {
            return this.entregado;
        }

        public int CompareTo(object a)
        {
            if (a is Videojuegos videojuego)
            {
                return this.horas.CompareTo(videojuego.horas);
            }
            else if (a is Videojuegos otroVideojuego)
            {
                return this.horas.CompareTo(otroVideojuego.horas);
            }
            else
            {
                throw new ArgumentException("El objeto proporcionado no es de tipo Serie ni Videojuego.");
            }
        }

        public Videojuegos()
        {
            this.titulo = "";
            this.horas = 10;
            this.entregado = false;
            this.genero = "";
            this.compania = "";
        }

        public Videojuegos(String titulo, int horas)
        {
            this.titulo = titulo;
            this.horas = horas;
            this.entregado = false;
            this.genero = "";
            this.compania = "";
        }

        public Videojuegos(String titulo, int horas, String genero, String compania)
        {
            this.titulo = titulo;
            this.horas = horas;
            this.entregado = false;
            this.genero = genero;
            this.compania = compania;
        }

        public override string ToString()
        {
            return $"Titulo: {this.titulo}, Horas estimadas: {this.horas}, Entregado: {this.entregado}, Genero: {this.genero}, Compañia: {this.compania}";
        }
    }

    public interface Entregable
    {
        void Entregar();
        void Devolver();
        bool IsEntregado();
        int CompareTo(Object a);
    }


    public class Program
    {
        public static void Main(string[] args)
        {

            Serie s1 = new Serie();
            Serie s2 = new Serie();
            Serie s3 = new Serie("Serie 1", 4, "Genero 1", "Creador 1");
            Serie s4 = new Serie("Serie 2", 5, "Genero 2", "Creador 2");
            Serie s5 = new Serie("Serie 3", 6, "Genero 3", "Creador 3");

            s3.Entregar();
            s5.Entregar();

            Serie[] arraySeries = new Serie[] {s1, s2, s3, s4, s5};

            Videojuegos v1 = new Videojuegos();
            Videojuegos v2 = new Videojuegos();
            Videojuegos v3 = new Videojuegos("Videojuego 1", 20);
            Videojuegos v4 = new Videojuegos("Videojuego 2", 40);
            Videojuegos v5 = new Videojuegos("Videojuego 3", 60);

            v2.Entregar();
            v4.Entregar();

            Videojuegos[] arrayVideojuegos = new Videojuegos[] {v1, v2, v3, v4, v5};

            Serie masTemporadas = arraySeries[0];
            Videojuegos masHoras = arrayVideojuegos[0];

            foreach (Serie serie in arraySeries)
            {
                if (serie.CompareTo(masTemporadas) > 0)
                {
                    masTemporadas = serie;
                }
            }

            foreach (Videojuegos videojuego in arrayVideojuegos)
            {
                if (videojuego.CompareTo(masHoras) > 0)
                {
                    masHoras = videojuego;
                }
            }

            Console.WriteLine(masHoras.ToString());
            Console.WriteLine(masTemporadas.ToString());

        }
    }
}