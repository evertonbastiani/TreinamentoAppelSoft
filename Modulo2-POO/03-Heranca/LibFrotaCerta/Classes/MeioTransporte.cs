using LibFrotaCerta.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibFrotaCerta.Classes
{
    public class MeioTransporte: IMeioTransporte
    {
       
        public string Cor { get; set; }      
        public string Combustivel { get; set; }

        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Ano { get; set; }

        public TipoTransporte Tipo { get; set; }

        public virtual void Mover()
        {
            switch (this.Tipo)
            {
                case TipoTransporte.Carro:
                    {
                        Console.WriteLine("Este é um veículo move se sobre 4 rodas.");
                        break;
                    }

                case TipoTransporte.Aviao:
                    {
                        Console.WriteLine("Este é um veículo move se sobre 2 asas.");
                        break;
                    }
                case TipoTransporte.Onibus:
                    {
                        Console.WriteLine("Este é um veículo move se sobre 6 rodas.");
                        break;
                    }
                case TipoTransporte.Motocicletas:
                    {
                        Console.WriteLine("Este é um veículo move se sobre 2 rodas.");
                        break;
                    }
                default:
                    break;
            }
        }
    }

    public enum TipoTransporte
    {
        Carro = 1,
        Aviao = 2,
        Onibus = 3,
        Motocicletas = 4
    }
}
