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
    [Table("Editoriales")]
    [Index(nameof(Nombre), IsUnique = true)]
    public class Editorial
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50, MinimumLength = 2)]
        public string Nombre { get; set; }
        public int PaisId {  get; set; }

        [ForeignKey("PaisId")]
        public Pais Pais { get; set; }
    }
}
