namespace TA28{
    public class Libros
    {
        private String _ISBN;
        private String _Titulo;
        private String _Autor;
        private int _Paginas;

        public String isbn
        {
            get { return _ISBN; }
            set { _ISBN = value; }
        }

        public String titulo
        {
            get { return _Titulo; }
            set { _Titulo = value; }
        }

        public String autor
        {
            get { return _Autor; }
            set { _Autor= value; }
        }

        public int paginas
        {
            get { return _Paginas; }
            set { _Paginas = value; }
        }

        public override string ToString()
        {
            return $": {this.titulo} con ISBN {this.isbn} creado por {this.autor} tiene {this.paginas} páginas.";
        }

        public Libros(String isbn, String titulo, String autor, int paginas)
        {
            this.isbn = isbn;
            this.titulo = titulo;
            this.autor = autor;
            this.paginas = paginas;
        }

    }

    public class Program
    {
        static void Comparar(Libros l1, Libros l2)
        {
            if (l1.paginas > l2.paginas)
            {
                Console.WriteLine("{0} tiene mas páginas que {1}", l1.titulo, l2.titulo);
            }
            else if (l2.paginas > l1.paginas)
            {
                Console.WriteLine("{0} tiene menos páginas que {1}", l1.titulo, l2.titulo);
            }
            else
            {
                Console.WriteLine("{0} y {1} tienen el mismo numero de paginas", l1.titulo, l2.titulo);
            }
        }
        public static void Main(string[] args)
        {
            Libros l1 = new Libros("123456", "Libro1", "Autor1", 100);
            Libros l2 = new Libros("789011", "Libro2", "Autor2", 200);

            Console.WriteLine(l1.ToString());
            Console.WriteLine(l2.ToString());

            Comparar(l1, l2);

        }
    }
}