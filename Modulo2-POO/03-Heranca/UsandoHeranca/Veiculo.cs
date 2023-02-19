using LibFrotaCerta.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsandoHeranca
{
    public class Veiculo : MeioTransporte
    {
        private readonly TipoTransporte _tipoTransporte;

        public Veiculo(TipoTransporte tipoTransporte)
        {
            _tipoTransporte = tipoTransporte;
        }

        public void ShowMe()
        {

            Console.WriteLine($"Marca: {this.Marca}");
            Console.WriteLine($"Modelo: {this.Modelo}");
            Console.WriteLine($"Ano: {this.Ano}");
            Console.WriteLine($"Cor: {this.Cor}");
            Console.WriteLine($"Combustivel: {this.Combustivel}");
            Console.WriteLine($"Tipo: {this._tipoTransporte}");

           
        }

        public override void Mover()
        {
            base.Tipo = _tipoTransporte;
            if (_tipoTransporte == TipoTransporte.Aviao)
            {
                base.Mover();
                Console.WriteLine("O avião está voando.");
            }
            if (_tipoTransporte == TipoTransporte.Carro)
            {
                
                base.Mover();
                Console.WriteLine("O Carro está andando.");
            }
            if (_tipoTransporte == TipoTransporte.Motocicletas)
            {
                base.Mover();
                Console.WriteLine("A moto está andando.");
            }
            if (_tipoTransporte == TipoTransporte.Onibus)
            {
                base.Mover();
                Console.WriteLine("O ônibus está partindo.");
            }
        }
    }
}
