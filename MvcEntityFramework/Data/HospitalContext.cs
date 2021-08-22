using Microsoft.EntityFrameworkCore;
using MvcEntityFramework.Models;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

#region PROCEDIMIENTOS ALMACENADOS
//create procedure MostrarDoctores
//as
//	select * from doctor
//go

//create procedure cambiarespecialidad
//(@iddoctor int, @especialidad nvarchar(30))
//as
//update doctor set especialidad = @especialidad
//where doctor_no = @iddoctor
//go


//create procedure especialidad
//as
//select distinct ESPECIALIDAD from DOCTOR
//go

//create procedure doctoresporespecialidad
//(@especialidad nvarchar(30))
//as
//    select* from DOCTOR where especialidad = @especialidad
//go

//create procedure cambiarsalario
//(@salario int, @especialidad nvarchar(30))
//as
//    update doctor set salario = salario + @salario where especialidad = @especialidad
//go

/// <summary>
//
/// </summary>

//create procedure procempleadoshospital
//(@hospitalcod int, @suma int out, @media int out)
//as
//    select* from empleadoshospital

//    where hospital_cod = @hospitalcod
//            select @suma = sum(salario), @media = avg(salario)

//    from empleadoshospital

//    where hospital_cod = @hospitalcod
//go
#endregion

namespace MvcEntityFramework.Data
{
    public class HospitalContext: DbContext
    {
        public HospitalContext(DbContextOptions options)
               :base(options)
        {
            
        }

        // Mapeamos cada entidad para que sea accesible
        public DbSet<Hospital> Hospitales { get; set; }
        public DbSet<Plantilla> Plantillas { get; set; }
        public DbSet<Doctor> Doctores { get; set; }

        public DbSet<EmpleadoHospital> EmpleadosHospital { get; set; }

        public DbSet<TodosEmpleados> TodosEmpleados { get; set; }

        // Creamos el primer procedimiento de accion
        public void ModificarEspecialidad(int iddoctor, String espe)
        {
            String sql = "cambiarespecialidad @iddoctor, @especialidad";

            SqlParameter pamid = new SqlParameter("@iddoctor", iddoctor);
            SqlParameter pamespe = new SqlParameter("@especialidad", espe);

            this.Database.ExecuteSqlRaw(sql, pamid, pamespe);
        }

       
    }
}
