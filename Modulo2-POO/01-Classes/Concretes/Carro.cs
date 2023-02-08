using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
