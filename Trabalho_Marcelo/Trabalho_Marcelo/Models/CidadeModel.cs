using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Trabalho_Marcelo.Models
{
    public class CidadeModel
    {
        [Key]
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Uf { get; set; }
    }
}