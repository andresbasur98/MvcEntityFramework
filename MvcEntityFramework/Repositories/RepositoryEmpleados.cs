using MvcEntityFramework.Data;
using MvcEntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcEntityFramework.Repositories
{
    public class RepositoryEmpleados
    {
        private EmpleadosContext context;

        public RepositoryEmpleados(EmpleadosContext context)
        {
            this.context = context;
        }

        public List<String> GetOficios()
        {
            var consulta = (from datos in this.context.Empleados
                            select datos.Oficio).Distinct();
            return consulta.ToList();
        }

        public List<Empleado> GetEmpleados()
        {
            //var consulta = from datos in this.context.Empleados
            //               select new { datos.IdEmpleado, datos.Apellido, datos.Oficio, datos.Salario };

            var consulta = from datos in this.context.Empleados
                           select datos;
            return consulta.ToList();
        }

        public List<Empleado> GetEmpleadosOficio(String oficio)
        {
            var consulta = from datos in this.context.Empleados
                           where datos.Oficio == oficio
                           select datos;
            if(consulta.Count() == 0)
            {
                return null;
            }
            return consulta.ToList();
        }

        public Empleado BuscarEmpleado(int idempleado)
        {
            var consulta = from datos in this.context.Empleados
                           where datos.IdEmpleado == idempleado
                           select datos;
            if(consulta.Count() == 0)
            {
                return null;
            }
            else
            {
                return consulta.First();
            }
        }

        public void IncrementarSalariosOficios(String oficio, int incremento)
        {
            List<Empleado> empleados = this.GetEmpleadosOficio(oficio);
            if(empleados != null)
            {
                 foreach(Empleado emp in empleados)
                {
                    emp.Salario += incremento;
                }
                this.context.SaveChanges();
            }
        }

        public ResumenDepartamento GetResumenDepartamento(int deptno)
        {
            List<Empleado> empleados = this.GetEmpleados();

            List<Empleado> filtro = empleados.Where(x => x.Departamento == deptno).ToList();
            if (filtro.Count() == 0)
            {
                return null;
            }
            int personas = filtro.Count();
            int maximo = filtro.Max(x => x.Salario);
            int minimo = filtro.Min(x => x.Salario);
            ResumenDepartamento resumen = new ResumenDepartamento();
            resumen.Empleados = filtro;
            resumen.Personas = personas;
            resumen.MaximoSalario = maximo;
            resumen.MaximoSalario = minimo;
            return resumen;
        }
    }
}
