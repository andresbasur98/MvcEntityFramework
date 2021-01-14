using Microsoft.AspNetCore.Mvc;
using MvcEntityFramework.Models;
using MvcEntityFramework.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcEntityFramework.Controllers
{
    public class EnfermosController : Controller
    {
        private RepositoryEnfermos repo;
        public EnfermosController(RepositoryEnfermos repo)
        {
            this.repo = repo;
        }
        public IActionResult Index()
        {
            List<Enfermo> enfermos = this.repo.GetEnfermos();
            return View(enfermos);
        }

        public IActionResult Details(int idinscripcion)
        {
            Enfermo enfermo = this.repo.BuscarEnfermo(idinscripcion);
            return View(enfermo);
        }

        public IActionResult EnfermosGenero(String genero)
        {
            List<Genero> generos = this.repo.GetGeneros();
            ViewData["GENEROS"] = generos;

            if(genero != null)
            {
                List<Enfermo> enfermos = this.repo.GetEnfermosGenero(genero);
                return View(enfermos);
            }
            else
            {
                return View();
            }

        }
    }
}
