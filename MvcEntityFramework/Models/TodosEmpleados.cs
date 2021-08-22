using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MvcEntityFramework.Models
{
    [Table("TODOSLOSEMPLEADOS")]
    public class TodosEmpleados
    {
        [Key]
        [Column("IDEMPLEADO")]
        public int IdEmpleado { get; set; }
        [Column("APELLIDO")]
        public String Apellido { get; set; }
        [Column("TRABAJO")]
        public String Trabajo { get; set; }
        [Column("SALARIO")]
        public int Salario { get; set; }
        [Column("DEPARTAMENTO/HOSPITAL")]
        public String DepHosp { get; set; }
        [Column("IDDEPART")]
        public int IdDepart { get; set; }

    }
}
