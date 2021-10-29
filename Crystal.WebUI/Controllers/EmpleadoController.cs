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
using Crystal.Domain.ViewModels;

namespace Crystal.WebUI.Controllers
{
    public class EmpleadoController : Controller
    {
        private readonly IGenericService<Empleado> _empService;
        private readonly IGenericService<Puesto> _puestoService;
        private readonly IEmpleadoService _dosEmpService;
        public EmpleadoController(IGenericService<Empleado> empService, IEmpleadoService dosEmpService, IGenericService<Puesto> puestoService)
        {
            _empService = empService;
            _dosEmpService = dosEmpService;
            _puestoService = puestoService;
        }

        // GET: Empleado
        public async Task<IActionResult> Index()
        {
            return View(await _dosEmpService.Leer());
        }

        // GET: Empleado/Create
        public async Task<IActionResult> Create()
        {
            ViewData["PuestoId"] = new SelectList(await _puestoService.Leer(), "ID", "Rol");
            return View();
        }

        // POST: Empleado/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EmpleadoViewModel empleado)
        {
            if (!(ModelState.IsValid))
            {
                ViewData["PuestoId"] = new SelectList(await _puestoService.Leer(), "ID", "Rol", empleado.PuestoId);
                return View(empleado);
            }

            await _dosEmpService.Crear(empleado);
            return RedirectToAction("Index");
        }

        // GET: Empleado/Edit/5
        public async Task<IActionResult> Edit(int id)
        {

            var empleado = await _empService.LeerUno(id);
            if (empleado == null)
            {
                return NotFound();
            }

            ViewData["PuestoId"] = new SelectList(await _puestoService.Leer(), "ID", "Rol", empleado.PuestoId);
            return View(empleado);
        }

        // POST: Empleado/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Nombre,Apellido,Usuario,Correo,PuestoId")] Empleado empleado)
        {
            if (id != empleado.ID)
            {
                return NotFound();
            }

            if (!(ModelState.IsValid))
            {
                ViewData["PuestoId"] = new SelectList(await _puestoService.Leer(), "ID", "Rol", empleado.PuestoId);
                return View(empleado);
            }

            await _empService.Actualizar(empleado.ID, empleado);
            return RedirectToAction("Index");

        }

        // GET: Empleado/Delete/5
        public async Task<IActionResult> Delete(int id)
        {

            var empleado = await _dosEmpService.LeerUno(id);
            if (empleado == null)
            {
                return NotFound();
            }

            return View(empleado);
        }

        // POST: Empleado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var empleado = await _dosEmpService.LeerUno(id);
            if (empleado == null)
            {
                return NotFound();
            }

            await _empService.Borrar(empleado.ID);
            return RedirectToAction(nameof(Index));
        }

    }
}
