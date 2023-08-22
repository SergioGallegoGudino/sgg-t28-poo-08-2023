using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

namespace TA28
{
    public class Electrodomestico
    {
        public enum Consumo
        {
            A,
            B,
            C,
            D,
            E,
            F
        }

        public enum Color
        {
            blanco,
            negro,
            rojo,
            azul,
            gris
        }

        private double _PrecioBase;
        private Color _Color;
        private Consumo _Consumo;
        private double _Peso;

        public double precio_base
        {
            get { return _PrecioBase; }
            set { _PrecioBase = value; }
        }

        public Color color
        {
            get { return _Color; }
            set { _Color = value; }
        }

        public Consumo consumo
        {
            get { return _Consumo; }
            set { _Consumo = value; }
        }

        public double peso
        {
            get { return _Peso; }
            set { _Peso = value; }
        }

        public double precioFinal()
        {
            double precioFinal = this.precio_base;

            switch (this.consumo)
            {
                case Consumo.A:
                    precioFinal += 100;
                break;

                case Consumo.B:
                    precioFinal += 80;
                    break;

                case Consumo.C:
                    precioFinal += 60;
                    break;

                case Consumo.D:
                    precioFinal += 50;
                    break;

                case Consumo.E:
                    precioFinal += 30;
                    break;

                case Consumo.F:
                    precioFinal += 10;
                    break;
            }

            if (this.peso >= 0 && this.peso <= 19)
            {
                precioFinal += 10;
            } else if (this.peso >= 20 && this.peso <= 49)
            {
                precioFinal += 50;
            } else if (this.peso >= 50 && this.peso <= 79)
            {
                precioFinal += 80;
            } else if (this.peso >= 80)
            {
                precioFinal += 100;
            }

            return precioFinal;

        }

        public Consumo comprobarConsumoEnergetico(char consumo)
        {
            if (Enum.IsDefined(typeof(Consumo), (Consumo)consumo))
            {
                return (Consumo)consumo;
            }
            else
            {
                return Consumo.F;
            }
        }

        public Color comprobarColor(char color)
        {
            if (Enum.IsDefined(typeof(Color), (Color)color))
            {
                return (Color)color;
            }
            else
            {
                return Color.blanco;
            }
        }

        public Electrodomestico()
        {
            this.precio_base = 100;
            this.color = Color.blanco;
            this.consumo = Consumo.F;
            this.peso = 5;
        }

        public Electrodomestico(double precio, double peso)
        {
            this.precio_base = precio;
            this.color = Color.blanco;
            this.consumo = Consumo.F;
            this.peso = peso;
        }

        public Electrodomestico(double precio, char color, char consumo, double peso)
        {
            this.precio_base = precio;
            this.color = comprobarColor(color);
            this.consumo = comprobarConsumoEnergetico(consumo);
            this.peso = peso;
        }
    }

    public class Lavadora : Electrodomestico
    {
        private double _Carga;

        public double carga
        {
            get { return _Carga; }
            set { _Carga = value; }
        }

        public double precioFinal()
        {
            double precioFinal = base.precioFinal();

            if (this.carga > 30)
            {
                precioFinal += 30;
            }

            return precioFinal;

        }

        public Lavadora()
        {
            this.precio_base = 100;
            this.color = Color.blanco;
            this.consumo = Consumo.F;
            this.peso = 5;
            this.carga = 5;
        }

        public Lavadora(double precio, double peso) : base(precio, peso)
        {
            this.precio_base = precio;
            this.color = Color.blanco;
            this.consumo = Consumo.F;
            this.peso = peso;
            this.carga = 5;
        }

        public Lavadora(double precio, char color, char consumo, double peso, double carga) : base(precio, color, consumo, peso)
        {
            this.precio_base = precio;
            this.color = comprobarColor(color);
            this.consumo = comprobarConsumoEnergetico(consumo);
            this.peso = peso;
            this.carga = carga;
        }
    }

    public class Television : Electrodomestico
    {
        private double _Resolucion;
        private Boolean _Sintonizador;

        public double resolucion
        {
            get { return _Resolucion; }
            set { _Resolucion = value; }
        }

        public Boolean sintonizador
        {
            get { return _Sintonizador; }
            set { _Sintonizador = value; }
        }

        public double precioFinal()
        {
            double precioFinal = base.precioFinal();

            if (this.resolucion > 40)
            {
                precioFinal = precioFinal + (precioFinal * 0.3);
            }

            if (sintonizador)
            {
                precioFinal += 50;
            }

            return precioFinal;

        }

        public Television()
        {
            this.precio_base = 100;
            this.color = Color.blanco;
            this.consumo = Consumo.F;
            this.peso = 5;
            this.resolucion = 20;
            this.sintonizador = false;
        }

        public Television(double precio, double peso): base(precio, peso)
        {
            this.precio_base = precio;
            this.color = Color.blanco;
            this.consumo = Consumo.F;
            this.peso = peso;
            this.resolucion = 20;
            this.sintonizador = false;
        }

        public Television(double precio, char color, char consumo, double peso, double resolucion, Boolean sintonizador) : base(precio, color, consumo, peso)
        {
            this.precio_base = precio;
            this.color = comprobarColor(color);
            this.consumo = comprobarConsumoEnergetico(consumo);
            this.peso = peso;
            this.resolucion = resolucion;
            this.sintonizador = sintonizador;
        }
    }

    public class Program
    {

        static void Main(String[] args)
        {

            Electrodomestico e1 = new Electrodomestico();
            Electrodomestico e2 = new Electrodomestico();
            Electrodomestico e3 = new Electrodomestico();

            Lavadora l1 = new Lavadora();
            Lavadora l2 = new Lavadora();
            Lavadora l3 = new Lavadora();

            Television t1 = new Television();
            Television t2 = new Television();
            Television t3 = new Television();
            Television t4 = new Television();

            Electrodomestico[] arrayElectrodomesticos = new Electrodomestico[] {e1,e2,e3,l1,l2,l3,t1,t2,t3,t4};

            double precioElectrodomesticos = 0;
            double precioLavadoras = 0;
            double precioTelevisores = 0;

            for (int i = 0; i < arrayElectrodomesticos.Length; i++)
            {
                if (arrayElectrodomesticos[i] is Lavadora)
                {
                    precioLavadoras += arrayElectrodomesticos[i].precioFinal();
                    precioElectrodomesticos += arrayElectrodomesticos[i].precioFinal();
                } else if (arrayElectrodomesticos[i] is Television)
                {
                    precioTelevisores += arrayElectrodomesticos[i].precioFinal();
                    precioElectrodomesticos += arrayElectrodomesticos[i].precioFinal();
                }
                else
                {
                    precioElectrodomesticos += arrayElectrodomesticos[i].precioFinal();
                }
            }

            Console.WriteLine("Precio final Lavadoras: " + precioLavadoras);
            Console.WriteLine("Precio final Televisores: " + precioTelevisores);
            Console.WriteLine("Precio final Electrodomesticos: " + precioElectrodomesticos);

        }
    }
}
