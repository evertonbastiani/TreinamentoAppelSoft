using Curso.Domain.Entities;
using Curso.Repository.Context;
using Curso.Repository.Interfaces;

namespace Curso.Repository.Repository
{
    public class VeiculoRepository : IVeiculoRepository
    {
        private readonly ITipoVeiculoRepository _tipoVeiculoRepository;
        private readonly CursoDBContext _context;


        public TipoVeiculo Tipo { get; set; }

        public VeiculoRepository(ITipoVeiculoRepository tipoVeiculoRepository, CursoDBContext context)
        {
            this._tipoVeiculoRepository = tipoVeiculoRepository;
            this.Tipo = new TipoVeiculo();
            _context = context;
        }

        public List<Veiculo> List()
        {
            return _context.Veiculo.OrderBy(x => x.Id).ToList();
        }

        public Veiculo Insert(Veiculo veiculo)
        {
            _context.Veiculo.Add(veiculo);
            _context.SaveChanges();
            return veiculo;
        }

        public bool Delete(long id)
        {
            var veiculo = this.Get(id);
            if (veiculo != null)
            {
                _context.Veiculo.Remove(veiculo);
                var deleted = _context.SaveChanges();
                return deleted > 0;
            }
            else
            {
                return false;
            }
        }

        public Veiculo Update(Veiculo veiculo)
        {
            _context.ChangeTracker.Clear();
            _context.Veiculo.Update(veiculo);
            _context.SaveChanges();

            return veiculo;
        }

        public Veiculo Get(long id)
        {
            return _context.Veiculo.Where(x => x.Id == id).FirstOrDefault();           
        }
    }
}
