using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

namespace TA28
{
    public class Password
    {
        private int _Longitud;
        private String _Passwd;

        public int longitud
        {
            get { return _Longitud; }
            set { _Longitud = value; }
        }

        public String passwd
        {
            get { return _Passwd; }
            set { _Passwd = value; }
        }

        public Password()
        {
            this.longitud = 8;
            this.passwd = "root";
        }

        public Boolean esFuerte()
        {
            String patron = @"^(.*[A-Z]){3,}(.*[a-z]){2,}(.*\d){6,}.*$";
            return Regex.IsMatch(this.passwd, patron);
        }

        public String generarPasswd()
        {
            String passwd = "";
            const String caracteresPermitidos = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*()_+[]{}|;:,.<>?";
            Random random = new Random();
            for (int i = 0; i < this.longitud; i++)
            {
                int index = random.Next(caracteresPermitidos.Length);
                passwd += caracteresPermitidos[index];
            }
            return passwd;
        }

        public Password(int longitud)
        {
            this.longitud = longitud;
            this.passwd = generarPasswd();
        }
    }

    public class Program
    {

        static void Main(String[] args)
        {
            Console.WriteLine("Indica el tamaño de la array de contraseñas: ");
            int num = int.Parse(Console.ReadLine());
            String[] passwdArray = new String[num];
            Boolean[] booleanArray = new Boolean[num];
            Console.WriteLine("Indica la longitud de las contraseñas: ");
            int longitud = int.Parse(Console.ReadLine());

            for (int i = 0;i < num; i++)
            {
                Password p1 = new Password(longitud);
                passwdArray[i] = p1.passwd;
                booleanArray[i] = p1.esFuerte();

                Console.WriteLine(passwdArray[i] + " " + booleanArray[i]);

            }

        }
    }
}
