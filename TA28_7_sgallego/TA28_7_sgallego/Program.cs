using System;
namespace TA28
{
    public class Raices
    {
        private double _CoeficienteA;
        private double _CoeficienteB;
        private double _CoeficienteC;

        public double coeficienteA
        {
            get { return _CoeficienteA; }
            set { _CoeficienteA = value; }
        }
        public double coeficienteB
        {
            get { return _CoeficienteB; }
            set { _CoeficienteB = value; }
        }
        public double coeficienteC
        {
            get { return _CoeficienteC; }
            set { _CoeficienteC = value; }
        }

        public void obtenerRaices()
        {
            double discriminante = getDiscriminante();

            if (discriminante > 0)
            {
                double raiz1 = (-this.coeficienteB + Math.Sqrt(discriminante)) / (2 * this.coeficienteA);
                double raiz2 = (-this.coeficienteB - Math.Sqrt(discriminante)) / (2 * this.coeficienteA);
                Console.WriteLine("Las dos posibles soluciones son:");
                Console.WriteLine("Raiz 1: " + raiz1);
                Console.WriteLine("Raiz 2: " + raiz2);
            }
            else if (discriminante == 0)
            {
                double raiz = -this.coeficienteB / (2 * this.coeficienteA);
                Console.WriteLine("La unica solucion es: " + raiz);
            }
            else
            {
                Console.WriteLine("No existen soluciones reales.");
            }
        }

        public double getDiscriminante()
        {
            return Math.Pow(this.coeficienteB, 2) - 4 * this.coeficienteA * this.coeficienteC;
        }

        public bool tieneRaices()
        {
            double discriminante = getDiscriminante();
            return discriminante >= 0;
        }

        public bool tieneRaiz()
        {
            double discriminante = getDiscriminante();
            return discriminante == 0;
        }

        public void calcular()
        {
            if (tieneRaices())
            {
                obtenerRaices();
            }
            else if (tieneRaiz())
            {
                obtenerRaices();
            }
            else
            {
                Console.WriteLine("No existen soluciones reales.");
            }
        }

        public Raices(double coeficienteA, double coeficienteB, double coeficienteC)
        {
            this.coeficienteA = coeficienteA;
            this.coeficienteB = coeficienteB;
            this.coeficienteC = coeficienteC;

        }

    }

    public class Program
    {
        public static void Main(string[] args)
        {
            Raices r1 = new Raices(1, -3, 2);
            Raices r2 = new Raices(1, -2, 1);
            Raices r3 = new Raices(1, 2, 5);

            Console.WriteLine("Ecuación 1:");
            r1.calcular();

            Console.WriteLine("Ecuación 2:");
            r2.calcular();

            Console.WriteLine("Ecuación 3:");
            r3.calcular();
        }
    }
    
}