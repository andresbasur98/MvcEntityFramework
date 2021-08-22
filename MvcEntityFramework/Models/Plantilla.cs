using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MvcEntityFramework.Models
{
    [Table("PLANTILLA")]
    public class Plantilla
    {
        [Key]
        [Column("HOSPITAL_COD")]
        public int IdHospital { get; set; }
        [Column("EMPLEADO_NO")]
        public int IdEmpleado { get; set; }
        [Column("APELLIDO")]
        public String Apellido { get; set; }
        [Column("SALARIO")]
        public int Salario { get; set; }
    }
}
