using LogicaNegocio.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Entidades
{
    [Table("Paises")]
    public class Pais
    {
        [Key]
        public int Id { get; set; }
        [Column("Nombre")]
        public RNombrePais Nombre {  get; set; }
    }
}
