using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace TiendaOnline.Models
{
    public class Categorias
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int CategoriaId { get; set; }
        public string Tipo { get; set; }
        public string Descripcion { get; set; }

        public ICollection <Articulos> Articulos { get; set; }

    }
}
