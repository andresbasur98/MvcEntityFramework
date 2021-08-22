using Microsoft.AspNetCore.Mvc;
using MvcEntityFramework.Models;
using MvcEntityFramework.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcEntityFramework.Controllers
{
    public class DoctoresController : Controller
    {
        RepositoryDoctores repo;
        public DoctoresController(RepositoryDoctores repo)
        {
            this.repo = repo;
        }
        public IActionResult Index()
        {
           
            return View();
        }       


        public IActionResult UpdateDoctoresEspecialidad()
        {
            List<Doctor> doctores = this.repo.GetDoctores();
            return View(doctores);
        }

        [HttpPost]
        public IActionResult UpdateDoctoresEspecialidad(int iddoctor, String especialidad)
        {
            this.repo.UpdateEspecialidad(iddoctor, especialidad);
            List<Doctor> doctores = this.repo.GetDoctores();
            return View(doctores);
        }

        public IActionResult ModificarSalarioDoctores()
        {
            List<Doctor> doctores = this.repo.GetDoctores();
            List<String> especialidades = this.repo.GetEspecialidades();
            ViewData["ESPECIALIDADES"] = especialidades;
            return View(doctores);
        }

        [HttpPost]
        public IActionResult ModificarSalarioDoctores(String especialidad, int incremento)
        {
            List<string> especialidades = this.repo.GetEspecialidades();
            ViewData["ESPECIALIDADES"] = especialidades;
            this.repo.UpdateSalarioEspecialidad(incremento, especialidad);
            List<Doctor> doctores = this.repo.GetDoctoresPorEspecialidad(especialidad);
            return View(doctores);
        }
    }
}
