using Classes.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
