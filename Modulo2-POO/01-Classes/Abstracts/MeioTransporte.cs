using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Classes.Abstracts
{
    public abstract class MeioTransporte
    {
        public abstract void tipoCombustivel();
       
        public void ExibirMeioTransporte()
        {
            Console.WriteLine($"Isto é um meio de transporte. {base.GetType().Name}");
        }
    }
}
