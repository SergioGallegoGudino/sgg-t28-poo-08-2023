using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

namespace TA28
{
    public class Persona
    {
        public enum Sexo
        {
            H,
            M
        };
        const Sexo sexoDefault = Sexo.H;

        private String _Nombre;
        private int _Edad;
        private String _DNI;
        private Sexo _Sexo;
        private double _Peso;
        private double _Altura;

        public String nombre
        {
            get { return _Nombre; }
            set { _Nombre= value; }
        }

        public int edad
        {
            get { return _Edad; }
            set { _Edad= value; }
        }

        public String dni
        {
            get { return _DNI; }
            set { _DNI= value; }
        }

        public Sexo sexo
        {
            get { return _Sexo; }
            set { _Sexo= value; }
        }

        public double peso
        {
            get { return _Peso; }
            set { _Peso = value; }
        }

        public double altura
        {
            get { return _Altura; }
            set { _Altura = value; }
        }

        public int calcularIMC()
        {
            if (this.peso / (this.altura * this.altura) < 20)
            {
                return -1;
            } else if (this.peso / (this.altura * this.altura) >= 20 && peso / (this.altura * this.altura) <= 25)
            {
                return 0;
            } else if (this.peso / (this.altura * this.altura) > 25)
            {
                return 1;
            } else //Nunca se dará este caso de forma realista
            {
                return 2;
            }
        }

        public Boolean esMayorDeEdad()
        {
            if (this.edad >= 18) {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Sexo comprobarSexo(char sexo)
        {
            if ((Sexo)sexo == Sexo.H || (Sexo)sexo == Sexo.M)
            {
                return (Sexo)sexo;
            }
            else
            {
                return Sexo.H;
            }
        }

        public override string ToString()
        {
            return $"Nombre: {this.nombre}, Edad: {this.edad}, DNI: {this.dni}, Sexo: {this.sexo}, Peso: {this.peso}, Altura: {this.altura}";
        }

        public String generaDNI()
        {
            char[] letras = "TRWAGMYFPDXBNJZSQVHLCKE".ToCharArray();

            Random random = new Random();
            int num = random.Next(10000000, 99999999);

            int index = num % 23;
            char letra = letras[index];

            String dni = "" + num + letra;

            Console.WriteLine(dni);

            return dni;
        }

        public Persona()
        {
            this.nombre = "";
            this.edad = 0;
            this.dni = generaDNI();
            this.sexo = sexoDefault;
            this.peso = 0;
            this.altura = 0;
        }

        public Persona(String nombre, int edad, char sexo)
        {
            this.nombre = nombre;
            this.edad = edad;
            this.dni = generaDNI();
            this.sexo = comprobarSexo(sexo);
            this.peso = 0;
            this.altura = 0;
        }

        public Persona(String nombre, int edad, char sexo, double peso, double altura)
        {
            this.nombre = nombre;
            this.edad = edad;
            this.dni = generaDNI();
            this.sexo = comprobarSexo(sexo);
            this.peso = peso;
            this.altura = altura;
        }
    }

    public class Program
    {

        public static void mensajePeso(int resultado)
        {
            if (resultado == -1)
            {
                Console.WriteLine("Está en su peso ideal");
            } else if (resultado == 0)
            {
                Console.WriteLine("Está por debajo de su peso ideal");
            } else if (resultado == 1)
            {
                Console.WriteLine("Tiene sobrepeso.");
            }
            else
            {
                Console.WriteLine("Erro de IMC, inténtelo de nuevo");
            }
        }

        static void Main(String[] args)
        {

            Console.WriteLine("Introduce tu nombre: ");
            String nombre = Console.ReadLine();
            Console.WriteLine("Introduce tu edad: ");
            int edad = int.Parse(Console.ReadLine());
            Console.WriteLine("Introduce tu sexo: ");
            char sexo = char.Parse(Console.ReadLine());
            Console.WriteLine("Introduce tu peso: ");
            double peso= double.Parse(Console.ReadLine());
            Console.WriteLine("Introduce tu altura: ");
            double altura = double.Parse(Console.ReadLine());

            Persona p1 = new Persona(nombre, edad, sexo, peso, altura);
            mensajePeso(p1.calcularIMC());
            p1.esMayorDeEdad();
            p1.ToString();
            Persona p2 = new Persona(nombre, edad, sexo);
            mensajePeso(p2.calcularIMC());
            p2.esMayorDeEdad();
            p2.ToString();
            Persona p3 = new Persona();
            mensajePeso(p3.calcularIMC());
            p3.esMayorDeEdad();
            p3.ToString();
        }
    }
}
