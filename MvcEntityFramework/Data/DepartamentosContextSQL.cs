using MvcEntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace MvcEntityFramework.Data
{
    public class DepartamentosContextSQL : IDepartamentosContext
    {
        private SqlDataAdapter addept;
        private DataTable tabladept;

        public DepartamentosContextSQL(String cadena)
        {
            //string cadena = "Data Source=LOCALHOST;Initial Catalog=HOSPITAL;Integrated Security=True";
            this.addept = new SqlDataAdapter("SELECT * FROM DEPT", cadena);
            this.tabladept = new DataTable();
            this.addept.Fill(tabladept);
        }

        public List<Departamento> GetDepartamentos()
        {
            // SELECT CON LINQ
            var consulta = from datos in this.tabladept.AsEnumerable()
                           select datos;

            List<Departamento> departamentos = new List<Departamento>();

            foreach(var dato in consulta)
            {
                // Creamos un objeto departamento
                Departamento dept = new Departamento();
                dept.Numero = dato.Field<int>("DEPT_NO");
                dept.Nombre = dato.Field<String>("DNOMBRE");
                dept.Localidad = dato.Field<String>("LOC");
                departamentos.Add(dept);
            }

            return departamentos;
        }
    }
}
