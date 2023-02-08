using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Contracts
{
    public interface IFrete
    {
        decimal CalcularFrete(decimal distancia);
        decimal CalcularFrete(decimal distancia, decimal fatorCalculo);
    }
}
