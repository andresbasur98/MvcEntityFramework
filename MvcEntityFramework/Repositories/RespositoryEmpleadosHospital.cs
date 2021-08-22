using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MvcEntityFramework.Data;
using MvcEntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcEntityFramework.Repositories
{
    public class RespositoryEmpleadosHospital
    {
        HospitalContext context;

        public RespositoryEmpleadosHospital(HospitalContext context)
        {
            this.context = context;
        }

        public List<EmpleadoHospital> GetEmpleadosHospital()
        {
            var consulta = from datos in this.context.EmpleadosHospital
                           select datos;
            return consulta.ToList();
        }

        public ProcedimientoEmpleadoHospital GetEmpleadoHospital(int hospitalcod)
        {
            String sql = "procempleadoshospital @hospitalcod, @suma out, @media out";
            SqlParameter pamcodigo = new SqlParameter("@hospitalcod", hospitalcod);
            SqlParameter pamsuma = new SqlParameter("@suma", -1);
            pamsuma.Direction = System.Data.ParameterDirection.Output;
            SqlParameter pamavg = new SqlParameter("@media", -1);
            pamavg.Direction = System.Data.ParameterDirection.Output;
            List<EmpleadoHospital> empleados = this.context.EmpleadosHospital.FromSqlRaw(sql, pamcodigo, pamsuma, pamavg).ToList();
            ProcedimientoEmpleadoHospital salida = new ProcedimientoEmpleadoHospital();
            salida.Empleados = empleados;
            salida.SumaSalarial = Convert.ToInt32(pamsuma.Value);
            salida.MediaSalarial = Convert.ToInt32(pamavg.Value);
            return salida;
        }
    }
}
