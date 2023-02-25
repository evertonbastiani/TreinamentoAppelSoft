using Classes.Abstracts;

namespace Classes.Concretes
{
    public class Caminhao : MeioTransporte
    {
        public override void tipoCombustivel()
        {
            Console.WriteLine("Este usa Diesel");
        }
    }
}
