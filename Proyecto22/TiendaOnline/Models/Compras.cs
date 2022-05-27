using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TiendaOnline.Models
{
    public class Compras
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int CompraId { get; set; }
        public int Cantidad { get; set; }
        public decimal Subtotal { get; set; }
        public DateTime Fecha { get; set; }=DateTime.Now;

        public int ArticuloID { get; set; }
        public int ProveedorID { get; set; }
        public int EmpleadoID { get; set; }

        public Articulos Articulo { get; set; }
        public Proveedores Proveedor { get; set; }
        public Empleados Empleado { get; set; }

    }
}
