using Classes.Abstracts;

namespace Classes.Concretes
{
    public class Carro : MeioTransporte
    {
        public override void tipoCombustivel()
        {
            Console.WriteLine("Este usa Gasolina");
        }
    }
}
