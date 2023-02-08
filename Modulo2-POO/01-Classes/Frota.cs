using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class Frota
    {
        public string Descricao { get; set; }
        public List<Veiculo> Veiculos { get; set; }

        public Frota() 
        {
            this.Veiculos = new List<Veiculo>();
        
        }

        public void AdicionarVeiculo(Veiculo veiculo)
        {
            this.Veiculos.Add(veiculo);
        }

        public List<Veiculo> ListarVeiculos()
        {
            return this.Veiculos;
        }
    }
}
