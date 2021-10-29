using Crystal.AppService.Servicios.Implementacion;
using Crystal.AppService.Servicios.interfaces;
using Crystal.Domain.Entidades;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crystal.WebUI.Controllers
{
    public class DepartamentoController : Controller
    {
        private readonly IGenericService<Departamento> _service;
        public DepartamentoController(IGenericService<Departamento> service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _service.Leer());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Departamento model)
        {
            if (!(ModelState.IsValid))
            {
                return View(model);
            }
            await _service.Crear(model);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int id)
        {
            return View(await _service.LeerUno(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(Departamento model)
        {
            if (!(ModelState.IsValid))
            {
                return View(model);
            }
            await _service.Actualizar(model.ID, model);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            return View(await _service.LeerUno(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Departamento model)
        {
            if (!(ModelState.IsValid))
            {
                return View(model);
            }
            await _service.Borrar(model.ID);
            return RedirectToAction("Index");
        }
    }
}
