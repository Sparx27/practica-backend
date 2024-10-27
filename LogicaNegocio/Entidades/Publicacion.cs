using LogicaNegocio.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Entidades
{
    [Table("Publicaciones")]
    public class Publicacion
    {
        public int Id { get; set; }
        public RNombrePublicacion Nombre {  get; set; }
        public int EditorialId { get; set; }
        public int Precio {  get; set; }
        [Column(TypeName = "date")]
        public DateTime FchPublicacion {  get; set; }
        public Antiguedad Antiguedad { get; set; }

        public ICollection<Autor> Autores { get; set; }
    }
}
