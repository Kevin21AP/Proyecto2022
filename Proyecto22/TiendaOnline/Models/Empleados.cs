    using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace TiendaOnline.Models
{
    public class Empleados
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int EmpleadoId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
   
        public int UsuarioID { get; set; }
        public Usuarios Usuario { get; set; }

        public ICollection<Ventas> Ventas { get; set; }
        public ICollection<Compras> Compras { get; set; }

    }
}
