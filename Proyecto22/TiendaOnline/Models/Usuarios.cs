using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TiendaOnline.Models
{
    
    public class Usuarios
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UsuarioId { get; set; }
        public string Correo { get; set; }
        public string Clave { get; set; }
        public string Rol { get; set; }
        public ICollection<Clientes> Clientes{ get; set; }
        public ICollection<Empleados> Empleados { get; set; }
        public ICollection<Carritos> Carritos { get; set; }


    }
}
