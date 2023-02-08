namespace TiposDados
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string nomeCurso = "Curso .NET Módulo 1";
            int duracaoCurso = 2; //semanas
            DateTime dataInicial = new DateTime(2023, 02, 13);
            DateTime dataFinal = new DateTime(2023, 02, 23);

            Console.WriteLine("Dados do Curso \r\n");
            Console.WriteLine($"Nome do curso: {nomeCurso}");
            Console.WriteLine($"Duração do curso: {duracaoCurso} semanas");
            Console.WriteLine($"Data inicial: {dataInicial}");
            Console.WriteLine($"Data final: {dataFinal}");

            Console.ReadLine();
        }
    }
}