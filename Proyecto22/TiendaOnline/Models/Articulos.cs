using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace TiendaOnline.Models
{
    public class Articulos
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ArticuloId { get; set; }
        public int Cantidad { get; set; }
        public string Nombre { get; set; }

        public string Imagen { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int CategoriaID { get; set; }
        
        public Categorias Categoria { get; set; }

        public ICollection<Ventas> Ventas { get; set; }

        public ICollection<Compras> Compras { get; set; }

        public ICollection<Carritos> Carritos { get; set; }

    }
}
