
namespace Ex6
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int valor = 1;
            do
            {
                var lines = File.ReadAllLines(@"C:\Users\felip\Área de Trabalho\cidades.csv");
                Console.WriteLine("(1) Procurar por estado\n(2) Procurar por letra\n(3) Mostrar todas as cidades ordenado!");

                valor = int.Parse(Console.ReadLine());

                Console.Clear();
                switch (valor)
                {
                    case 1:
                        procuraPorEstado(lines);
                        break;

                    case 2:
                        
                        procuraLetra(lines);
                        break;

                    case 3:
                        mostrarOrdenado(lines); 
                        break;

                }

            }while(valor != 0);
            }
           

        private static void procuraPorEstado(string[] lines)
        {
            Console.WriteLine("Qual estado: ");
            string cidadeProcura = Console.ReadLine();

            if(cidadeProcura.Contains(" "))
            {
                string[] palavras = cidadeProcura.Split(' ');
                string iniciais = "";
                foreach (string palavra in palavras)
                {
                    iniciais += palavra[0];
                }

                foreach (var line in lines)
                {
                    string estado = line.Split(';')[3];

                    string[] palavrasEstado = estado.Split(' ');
                    string iniciaisEstado = "";

                    foreach (string palavra in palavrasEstado)
                    {
                        var palavraSemEspaco = palavra.Trim();
                        iniciaisEstado += palavraSemEspaco[0];
                    }

                    string cidade = line.Split(';')[2];

                    if (String.Compare(iniciaisEstado, iniciais, true) == 0)
                    {
                        Console.Write(cidade + ", ");
                    }
                }

                Console.ReadLine();
                Console.Clear();
            }

            else
            {
                foreach (var line in lines)
                {
                    string estado = line.Split(';')[3];
                    string cidade = line.Split(';')[2];

                    if (String.Compare(cidadeProcura, estado, true) == 0) ;
                    {
                        Console.Write(cidade + ", ");
                    }
                }
            }

            
        }

        private static void procuraLetra(string[] lines)
        {
            Console.WriteLine("Qual letra deseja procurar?");
            string letra = Console.ReadLine();

            foreach (var line in lines)
            {

                string cidade = line.Split(';')[2];
                string estado = line.Split(";")[3];

                if (cidade.StartsWith(letra, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"Cidade: {cidade}, Estado: {estado}");
                }

            }

            Console.ReadLine();
            Console.Clear();
        }

        static void mostrarOrdenado(string[] lines)
        {
            string letras = "abcdefghijklmnopqrstuvwxyz";

            foreach (var letra in letras)
            {
                foreach (var line in lines)
                {
                    string cidade = line.Split(';')[2];
                    string estado = line.Split(";")[3];

                    if (cidade.StartsWith(letra.ToString(), StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine($"Cidade: {cidade}, Estado: {estado}");
                    }
                }
            }
        }
    }
}