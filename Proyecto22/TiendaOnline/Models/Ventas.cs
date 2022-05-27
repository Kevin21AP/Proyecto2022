using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace TiendaOnline.Models
{
    public class Ventas
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int VentaId { get; set; }
        public DateTime Fecha { get; set; }=DateTime.Now;
        public int Cantidad { get; set; }
        public decimal SubTotal { get; set; }

        public int ArticuloID { get; set; }
        public int ClienteID { get; set; }
        public int PagoID { get; set; }
        public int EmpleadoID { get; set; }


        public Articulos Articulo { get; set; }
        public Clientes Cliente { get; set; }
        public Pagos Pago { get; set; }
        public Empleados Empleado { get; set; }
    }
}
