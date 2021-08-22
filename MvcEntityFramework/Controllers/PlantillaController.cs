using Microsoft.AspNetCore.Mvc;
using MvcEntityFramework.Models;
using MvcEntityFramework.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcEntityFramework.Controllers
{
    public class PlantillaController : Controller
    {
        private RepositoryPlantilla repo;

        public PlantillaController(RepositoryPlantilla repo)
        {
            this.repo = repo;
        }
        public IActionResult Index()
        {
            List<Plantilla> plantilla = this.repo.GetPlantilla();
            return View(plantilla);
        }

        public IActionResult PlantillaLambda()
        {
            return View();
        }

        [HttpPost]
        public IActionResult PlantillaLambda(int salario)
        {
            ResumenPlantilla model = this.repo.GetPlantillaSalario(salario);
            return View(model);
        }
    }
}
