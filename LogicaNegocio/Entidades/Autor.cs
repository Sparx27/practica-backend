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
    [Table("Autores")]
    public class Autor
    {
        public int Id { get; set; }
        [Column("Nombre")]
        [Required]
        public RNombreAutor Nombre { get; set; }
        [Column(TypeName = "date")]
        public DateTime FchNacimiento { get; set; }
        public int Nacionalidad { get; set; }

        [ForeignKey("Nacionalidad")]
        public Pais Pais { get; set; }

        public ICollection<Publicacion> Publicaciones { get; set; }
    }
}
