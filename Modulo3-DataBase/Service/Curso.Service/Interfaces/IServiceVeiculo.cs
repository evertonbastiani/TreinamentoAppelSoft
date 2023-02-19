﻿using Curso.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso.Service.Interfaces
{
    public interface IServiceVeiculo
    {
        List<VeiculoDTO> List();
        VeiculoDTO Insert(VeiculoDTO veiculoDB);
        bool Delete(long id);
        VeiculoDTO Update(VeiculoDTO veiculoDB);
        VeiculoDTO Get(long id);
    }
}