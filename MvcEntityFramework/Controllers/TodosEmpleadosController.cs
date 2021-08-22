using Microsoft.AspNetCore.Mvc;
using MvcEntityFramework.Models;
using MvcEntityFramework.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcEntityFramework.Controllers
{
    public class TodosEmpleadosController : Controller
    {
        private RepositoryTodosEmpleados repo;

        public TodosEmpleadosController(RepositoryTodosEmpleados repo)
        {
            this.repo = repo;
        }
        public IActionResult Index()
        {
            List<TodosEmpleados> empleados = this.repo.GetEmpleados();
            return View(empleados);
        }

        public IActionResult TodosEmpleadosCod()
        {
            return View();
        }

        [HttpPost]
        public IActionResult TodosEmpleadosCod(int codigo)
        {
            ProcedimientoEmpleado datos = this.repo.GetEmpleadoPorDept(codigo);
            return View(datos);
        }

        public IActionResult EmpleadosDesplegable()
        {
            List<String> HospDepts = this.repo.NombresHospDept();
            return View(HospDepts);
        }
    }
}
