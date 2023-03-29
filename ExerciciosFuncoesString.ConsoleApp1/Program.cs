using System.Globalization;
using System.Linq;
using System.Xml;

namespace ExerciciosFuncoesString.ConsoleApp1
{
    internal class Program
    {

        static string pegarFrase(string frase)
        {
            Console.WriteLine(frase);
            string palavra = Console.ReadLine();

            return palavra;
        }

        static string TranformarEmTitleCase(string palavra)
        {
            string palavraMinusculo = palavra.ToLower();
            string palavraTitle = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(palavra.ToLower());


            return palavraTitle;
        }

        static string[] DescobrirQuantidadePalavras(string palavra)
        {
           string[] quantidade =  palavra.Split(' ');
            return quantidade;
        }

        static string TranformarEmCesar(string palavra)
        {

            string resultado = "";

            foreach (char c in palavra)
            {
                if (c != ' ')
                {
                    int codigo = Convert.ToInt32(c) + 2;
                    resultado += Convert.ToChar(codigo);
                }
                else
                    resultado += ' ';
                    continue;
               
            }


            return resultado;
        }

        static int EncotrnarCincoMaiores(ref string cincoMaiores)
        {
            string numeros = "73167176531330624919225119674426574742355349194934\r\n96983520312774506326239578318016984801869478851843\r\n85861560789112949495459501737958331952853208805511\r\n12540698747158523863050715693290963295227443043557\r\n66896648950445244523161731856403098711121722383113\r\n62229893423380308135336276614282806444486645238749\r\n30358907296290491560440772390713810515859307960866\r\n70172427121883998797908792274921901699720888093776\r\n65727333001053367881220235421809751254540594752243\r\n52584907711670556013604839586446706324415722155397\r\n53697817977846174064955149290862569321978468622482\r\n83972241375657056057490261407972968652414535100474\r\n82166370484403199890008895243450658541227588666881\r\n16427171479924442928230863465674813919123162824586\r\n17866458359124566529476545682848912883142607690042\r\n32421902267105562632111110937054421750694165896040\r\n07198403850962455444362981230987879927244284909188\r\n84580156166097919133875499200524063689912560717606\r\n05886116467109405077541002256983155200055935729725\r\n71636269561882670428252483600823257530420752963450";
            int resultado;
            int cincoEmCinco = 5, primeiroValor = 1, maiorValor = 0, terceiroValor = 0, zeroDeCinco = 0;
            cincoMaiores = "";
            int[] intNovoNumeros = new int[1038];

            for (int i = 0; i < numeros.Length; i++)
            {
                if (zeroDeCinco + cincoEmCinco <= numeros.Length)
                {
                    string novoNumeros = (numeros.Substring(zeroDeCinco, 5));

                    for (int j = 0; j < 5; j++)
                    {
                        intNovoNumeros[j] = (int)Char.GetNumericValue(novoNumeros[j]);
                        primeiroValor *= intNovoNumeros[j];

                        if (primeiroValor > maiorValor)
                        {
                            cincoMaiores = novoNumeros;
                            maiorValor = primeiroValor;
                        }
                    }
                    novoNumeros = "";
                }
                
                primeiroValor = 1;
                cincoEmCinco += 5;
                zeroDeCinco += 5;   
            }

            return maiorValor;
        }

        static void questaoCinco(ref string palavraMasc, ref string palavraMinus, ref int tamanhoFrase, ref string primeiraPalavra, ref string ultimaPalavra, string palavra)
        {

            palavraMasc = palavra.ToUpper();
            palavraMinus = palavra.ToLower();
            tamanhoFrase = palavra.Length;
            primeiraPalavra = palavra.Split(' ')[0];
            int ultimoIndex = palavra.Split(' ').Length;
            ultimaPalavra = palavra.Split()[ultimoIndex - 1];

        }

        //static void questaoSeis(string municipios)
        //{
        //    List<string> estados = new List<string>();

        //    var lines = File.ReadAllLines(@"C:\Users\felip\Área de Trabalho\cidades.csv");

        //    foreach (var line in lines)
        //    {
        //        string teste = line.Split(";")[3];

        //        string alfabeto = "abcdefghijklmnopqrstuvwxyz".ToUpper();


        //        foreach (var letra in alfabeto)
        //        {
        //            if (teste.StartsWith(letra))
        //            {
        //                if (!estados.Contains(letra.ToString()))
        //                {
        //                    int contador = 0;
        //                    estados[contador] = new List<>();
        //                    contador++;
        //                }
        //            }
        //        }
        //    }



        //}





        static void Main(string[] args)
        {
            int tamanhoFrase = 0;
            string cincoMaiores = "", palavraMasc = "", palavraMinus = "", primeiraPalavra = "", ultimaPalavra = "";
            EncotrnarCincoMaiores(ref cincoMaiores);

            string palavra = pegarFrase("Qual a frase deseja tranformar: ");

            Console.WriteLine($"\nA frase em TitleCase fica assim: { TranformarEmTitleCase(palavra)}");

            string[] quantide = DescobrirQuantidadePalavras(palavra);
            Console.WriteLine($"A quantidade de palavras eh {quantide.Length}");

            Console.WriteLine($"O codigo com codigicacao Cesariana fica assim: {TranformarEmCesar(palavra)}");

            Console.WriteLine($"A combinacao dos cinco maiores numero sao {cincoMaiores} resultando em {EncotrnarCincoMaiores(ref cincoMaiores)}");

            questaoCinco(ref palavraMasc, ref palavraMinus, ref tamanhoFrase, ref primeiraPalavra, ref ultimaPalavra, palavra);

            Console.WriteLine($"A palavra em MAIUSCULO fica: {palavraMasc} \nA palavra em minusculo fica: {palavraMinus}\nA frase tem {tamanhoFrase} caracteres\nA primeira palavra eh: {primeiraPalavra}\nA ultima palavra eh: {ultimaPalavra}");


            string municipios = File.ReadAllText(@"C:\Users\felip\Área de Trabalho\cidades.csv");

            


        }
    
}   }