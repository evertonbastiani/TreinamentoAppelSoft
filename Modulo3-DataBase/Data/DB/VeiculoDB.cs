using Curso.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso.Data.DB
{
    public class VeiculoDB: IVeiculoDataOperation
    {
        public int Id { get; set; }
        public string ?Marca { get; set; }
        public string ?Modelo { get; set; }
        public int Ano { get; set; }
        public string ?Cor { get; set; }
        public string ?Placa { get; set; }

        public bool Delete(long id)
        {
            throw new NotImplementedException();
        }

        public VeiculoDB Insert(VeiculoDB veiculoDB)
        {
            throw new NotImplementedException();
        }

        public List<VeiculoDB> List()
        {
            throw new NotImplementedException();
        }

        public VeiculoDB Update(VeiculoDB veiculoDB)
        {
            throw new NotImplementedException();
        }
    }
}
