using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

namespace TA28
{
    public class Cuenta
    {
        private String _Titular;
        private double _Cantidad;

        public double cantidad
        {
            get { return _Cantidad; }
            set { _Cantidad = value; }
        }

        public String titular
        {
            get { return _Titular; }
            set { _Titular = value; }
        }

        public void ingresar(double cantidad)
        {
            if (cantidad > 0)
            {
                this.cantidad += cantidad;
                Console.WriteLine("Cantidad actual: {0}", this.cantidad);
            } else
            {
                Console.WriteLine("Por favor, introduce un valor positivo");
            }
        }

        public void retirar(double cantidad)
        {
            this.cantidad -= cantidad;
            if (this.cantidad < 0)
            {
                this.cantidad = 0;
            }
            Console.WriteLine("Cantidad actual: {0}", this.cantidad);
        }

        public Cuenta(String titular)
        {

            this.titular = titular;
            cantidad = 0;

        }

        public Cuenta(String titular, double cantidad)
        {

            this.titular = titular;
            this.cantidad = cantidad;

        }

        public override String ToString()
        {
            return $"Titular: {this.titular}, Cantidad: {this.cantidad}";
        }
    }

    public class Program
    {
        static void Main(String[] args)
        {
            Cuenta c1 = new Cuenta("Sergio Gallego", 1000);
            Cuenta c2 = new Cuenta("Alex Lanzon");

            c1.ingresar(100);
            c2.retirar(10);

            Console.WriteLine(c1.ToString());
            Console.WriteLine(c2.ToString());
        }
    }
}

