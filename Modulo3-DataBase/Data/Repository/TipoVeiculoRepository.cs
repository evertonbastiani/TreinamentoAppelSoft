using Curso.Domain.Entities;
using Curso.Repository.Context;
using Curso.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32.SafeHandles;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso.Repository.Repository
{
    public class TipoVeiculoRepository :ITipoVeiculoRepository
    {
        private readonly CursoDBContext _context;
        public TipoVeiculoRepository(CursoDBContext context)
        {
            _context = context;
        }

        public List<TipoVeiculo> List()
        {
            return _context.TipoVeiculo.OrderBy(x => x.Id).ToList();        
        }

        public TipoVeiculo Insert(TipoVeiculo tipoVeiculo)
        {
            _context.TipoVeiculo.Add(tipoVeiculo);
            _context.SaveChanges();
            return tipoVeiculo;
        }

        public bool Delete(long id)
        {
            var tipoVeiculo = this.Get(id);
            if(tipoVeiculo != null)
            {
                _context.TipoVeiculo.Remove(tipoVeiculo);
                var deleted = _context.SaveChanges();
                return deleted > 0;
            }else
            {
                return false;
            }           
        }

        public TipoVeiculo Update(TipoVeiculo tipoVeiculo)
        {
            _context.ChangeTracker.Clear();
            _context.TipoVeiculo.Update(tipoVeiculo);
            _context.SaveChanges();
            return tipoVeiculo;
        }

        public TipoVeiculo Get(long id)
        {
            return _context.TipoVeiculo.Where(x => x.Id == id).FirstOrDefault();           
        }
    }


}
