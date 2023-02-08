using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    
    public static class Frete
    {
        private const decimal fatorCalculo = 5.98M;

        public static decimal CalcularFrete(decimal distancia)
        {
            return (distancia * fatorCalculo);
        }
    }
}
