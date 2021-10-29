using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Crystal.Data.Contexto;
using Crystal.Domain.Entidades;
using Crystal.AppService.Servicios.interfaces;

namespace Crystal.WebUI.Controllers
{
    public class PuestoController : Controller
    {
        private readonly IGenericService<Puesto> _puestoService;
        private readonly IGenericService<Departamento> _depaService;
        private readonly IPuestoService _dosPuestoService;
        public PuestoController(IGenericService<Puesto> puestoService, IGenericService<Departamento> depaService, IPuestoService dosPuestoService)
        {
            _puestoService = puestoService;
            _depaService = depaService;
            _dosPuestoService = dosPuestoService;
        }

        // GET: Puesto
        public async Task<IActionResult> Index()
        {
            return View(await _dosPuestoService.Leer());
        }

        // GET: Puesto/Create
        public async Task<IActionResult> Create()
        {
            ViewData["DepartamentoID"] = new SelectList(await _depaService.Leer(), "ID", "Nombre");
            return View();
        }

        // POST: Puesto/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Rol,Sueldo,DepartamentoID")] Puesto puesto)
        {
            if (!(ModelState.IsValid))
            {
                ViewData["DepartamentoID"] = new SelectList(await _depaService.Leer(), "ID", "Nombre", puesto.DepartamentoID);
                return View(puesto);
            }

            await _puestoService.Crear(puesto);
            return RedirectToAction("Index");
        }

        // GET: Puesto/Edit/5
        public async Task<IActionResult> Edit(int id)
        {  

            var puesto = await _puestoService.LeerUno(id);
            if (puesto == null)
            {
                return NotFound();
            }
            ViewData["DepartamentoID"] = new SelectList(await _depaService.Leer(), "ID", "Nombre", puesto.DepartamentoID);
            return View(puesto);
        }

        // POST: Puesto/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Rol,Sueldo,DepartamentoID")] Puesto puesto)
        {
            if (id != puesto.ID)
            {
                return NotFound();
            }

            if (!(ModelState.IsValid))
            {
                ViewData["DepartamentoID"] = new SelectList(await _depaService.Leer(), "ID", "Nombre", puesto.DepartamentoID);
                return View(puesto);
            }

            await _puestoService.Actualizar(puesto.ID, puesto);
            return RedirectToAction("Index");
        }

        // GET: Puesto/Delete/5
        public async Task<IActionResult> Delete(int id)
        {

            var puesto = await _dosPuestoService.LeerUno(id);

            if (puesto == null)
            {
                return NotFound();
            }

            return View(puesto);
        }

        // POST: Puesto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _puestoService.Borrar(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
