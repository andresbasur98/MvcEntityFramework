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
    public class RepositoryDoctores
    {
        HospitalContext context;
        public RepositoryDoctores (HospitalContext context)
        {
            this.context = context;
        }

        public void UpdateEspecialidad(int iddoctor, String espe)
        {
            this.context.ModificarEspecialidad(iddoctor, espe);
        }

       

        // PROCEDIMIENTO ALMACENADO CON SELECT
        public List<Doctor> GetDoctores()
        {
            String sql = "mostrardoctores";


            return this.context.Doctores.FromSqlRaw(sql).ToList();
        }

       

        public List<Doctor> GetDoctoresPorEspecialidad(String espe)
        {
            string sql = "doctoresporespecialidad @especialidad";
            SqlParameter pamespe = new SqlParameter("@especialidad", espe);

            List<Doctor> doctores = this.context.Doctores.FromSqlRaw(sql, pamespe).ToList();
            return doctores;
        }

        public void UpdateSalarioEspecialidad(int salario, String espe)
        {
            string sql = "cambiarsalario @salario, @especialidad";
            SqlParameter pamespe = new SqlParameter("@especialidad", espe);
            SqlParameter paminc = new SqlParameter("@salario", salario);

            this.context.Database.ExecuteSqlRaw(sql, pamespe, paminc);
        }

        //public List<String> GetEspecialidad()
        //{
        //    var consulta = (from datos in this.context.Doctores
        //                    select datos.Especialidad).Distinct();
        //    //List<String> especialidades = new List<String>();
        //    //foreach (String dato in consulta)
        //    //{
        //    //    especialidades.Add(dato);
        //    //}
        //    return consulta.ToList();

        //}

        public List<String> GetEspecialidades()
        {
            using (DbCommand com = this.context.Database.GetDbConnection().CreateCommand())
            {
                String sql = "especialidad";
                com.CommandType = System.Data.CommandType.StoredProcedure;
                com.CommandText = sql;
                com.Connection.Open();
                DbDataReader reader = com.ExecuteReader();
                List<string> especialidades = new List<string>();
                while (reader.Read())
                {
                    especialidades.Add(reader["ESPECIALIDAD"].ToString());
                }
                reader.Close();
                com.Connection.Close();
                return especialidades;
            }
        }
    }
}
