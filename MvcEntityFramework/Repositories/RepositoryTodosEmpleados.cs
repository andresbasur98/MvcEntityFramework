using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MvcEntityFramework.Data;
using MvcEntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace MvcEntityFramework.Repositories
{
    public class RepositoryTodosEmpleados
    {
        HospitalContext context;

        public RepositoryTodosEmpleados(HospitalContext context)
        {
            this.context = context;
        }

        public List<TodosEmpleados> GetEmpleados()
        {
            var consulta = from datos in this.context.TodosEmpleados
                           select datos;
            return consulta.ToList();
        }

        public ProcedimientoEmpleado GetEmpleadoPorDept(int cod)
        {
            String sql = "empleadosporcodigo @iddepartamento, @suma out, @media out";
            SqlParameter pamcodigo = new SqlParameter("@iddepartamento", cod);
            SqlParameter pamsuma = new SqlParameter("@suma", -1);
            pamsuma.Direction = System.Data.ParameterDirection.Output;
            SqlParameter pamavg = new SqlParameter("@media", -1);
            pamavg.Direction = System.Data.ParameterDirection.Output;
            List<TodosEmpleados> empleados = this.context.TodosEmpleados.FromSqlRaw(sql, pamcodigo, pamsuma, pamavg).ToList();
            ProcedimientoEmpleado salida = new ProcedimientoEmpleado();
            salida.Empleados = empleados;
            salida.SumaSalarial = Convert.ToInt32(pamsuma.Value);
            salida.MediaSalarial = Convert.ToInt32(pamavg.Value);
            return salida;
        }

        public List<DesplegableEmpleados> NombresHospDept()
        {
            using (DbCommand com = this.context.Database.GetDbConnection().CreateCommand())
            {
                String sql = "depshospitales";
                com.CommandType = System.Data.CommandType.StoredProcedure;
                com.CommandText = sql;
                com.Connection.Open();
                DbDataReader reader = com.ExecuteReader();
                List<DesplegableEmpleados> hospdeps = new List<DesplegableEmpleados>();
                while (reader.Read())
                {
                   DesplegableEmpleados hospdep = new DesplegableEmpleados();
                    hospdep.DepsHosps = reader["Departamento/Hospital"].ToString();
                    hospdep.IdDept = Convert.ToInt32(reader["IdDepart"]);
                    hospdeps.Add(hospdep);
                }
                reader.Close();
                com.Connection.Close();
                return hospdeps;
            }

        } 
    }
}
