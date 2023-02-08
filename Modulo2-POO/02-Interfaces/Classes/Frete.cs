using Interfaces.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Classes
{
    public class Frete : IFrete
    {
        private decimal fatorInterno = 6.5M;
        public decimal CalcularFrete(decimal distancia)
        {
            return (distancia * fatorInterno);
        }

        public decimal CalcularFrete(decimal distancia, decimal fatorCalculo)
        {
            return (distancia * fatorCalculo);
        }
    }
}
