using LibFrotaCerta.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsandoHeranca
{
    public  class Veiculo:MeioTransporte
    {
      

        public Veiculo(TipoTransporte tipo) 
        {
            this.Tipo = tipo;
        }

        public void ShowMe()
        {
           
            Console.WriteLine($"Marca: {this.Marca}");
            Console.WriteLine($"Modelo: {this.Modelo}");
            Console.WriteLine($"Ano: {this.Ano}");
            Console.WriteLine($"Cor: {this.Cor}");
            Console.WriteLine($"Combustivel: {this.Combustivel}");
            Console.WriteLine($"Tipo: {this.Tipo}");          

        }

        public override void Mover()
        {
            if(Tipo == TipoTransporte.Aviao)
            {
                base.Mover();
                Console.WriteLine("O avião está voando.");
            }
           
        }
    }
}
