using MvcEntityFramework.Data;
using MvcEntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcEntityFramework.Repositories
{
    public class RepositoryPlantilla
    {
        private HospitalContext context;

        public RepositoryPlantilla(HospitalContext context)
        {
            this.context = context;
        }

        public List<Plantilla> GetPlantilla()
        {
            var consulta = from datos in this.context.Plantillas
                           select datos;
            return consulta.ToList();
        }

        public ResumenPlantilla GetPlantillaSalario(int salario)
        {
            List<Plantilla> plantilla = this.GetPlantilla();

            List<Plantilla> filtro = plantilla.Where(x => x.Salario >= salario).ToList();
            if (filtro.Count() == 0)
            {
                return null;
            }
            int personas = filtro.Count();
            int maximo = filtro.Max(x => x.Salario);
            int minimo = filtro.Min(x => x.Salario);
            ResumenPlantilla resumen = new ResumenPlantilla();
            resumen.Plantilla = filtro;
            resumen.Personas = personas;
            resumen.MaximoSalario = maximo;
            resumen.MaximoSalario = minimo;
            return resumen;
        }
    }
}
