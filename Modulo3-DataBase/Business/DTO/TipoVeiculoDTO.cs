﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso.Domain.DTO
{
    public class TipoVeiculoDTO
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "O campo descrição é obrigatório.")]
        public string? Descricao { get; set; }
    }
}
