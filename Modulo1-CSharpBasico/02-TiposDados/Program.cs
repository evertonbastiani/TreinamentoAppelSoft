namespace TiposDados
{
    internal class Program
    {
        //Variáveis globais
        const string nomePrograma = "Estudo CSharp";
        static string nomeCurso = "Curso .NET Módulo 1";
        static void Main(string[] args)
        {
            //Variáveis locais
           
            int duracaoCurso = 2; //semanas
            DateTime dataInicial = new DateTime(2023, 02, 13);
            DateTime dataFinal = new DateTime(2023, 02, 23);

            Console.WriteLine("Dados do Curso \r\n");
            Console.WriteLine($"Nome do curso: {nomeCurso}");
            Console.WriteLine($"Duração do curso: {duracaoCurso} semanas");
            Console.WriteLine($"Data inicial: {dataInicial}");
            Console.WriteLine($"Data final: {dataFinal}");

            //Constantes não podem ser modificadas. 
            //nomePrograma = "Teste";
            Console.WriteLine($"O nome do programa é {nomePrograma}. Não conseguimos modificar uma constante.");

            nomeCurso = "CSharp modificado";
            Console.WriteLine($"Nome do curso: {nomeCurso}");

            Console.ReadLine();
        }
    }
}