using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace TiendaOnline.Models
{
    public class Articulos
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ArticuloId { get; set; }
        [Required]
        public int Cantidad { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Descripcion { get; set; }
        [Required]
        public decimal Precio { get; set; }
        [Required]
        public int CategoriaID { get; set; }
        
        public Categorias Categoria { get; set; }

        public ICollection<Ventas> Ventas { get; set; }

        public ICollection<Compras> Compras { get; set; }

        public ICollection<Carritos> Carritos { get; set; }

    }
}
