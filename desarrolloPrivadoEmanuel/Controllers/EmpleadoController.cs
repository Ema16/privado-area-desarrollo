using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using desarrolloPrivadoEmanuel.Models;
using Rotativa.AspNetCore;

namespace desarrolloPrivadoEmanuel.Controllers
{
    public class EmpleadoController : Controller
    {
        private readonly DbEmpleadosContext _context;

        public EmpleadoController(DbEmpleadosContext context)
        {
            _context = context;
        }

        // GET: Empleado
        public async Task<IActionResult> Index()
        {
            var dbEmpleadosContext = _context.Empleados.Include(e => e.CodPuestoNavigation);
            return View(await dbEmpleadosContext.ToListAsync());
        }

        // GET: Empleado/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Empleados == null)
            {
                return NotFound();
            }

            var empleado = await _context.Empleados
                .Include(e => e.CodPuestoNavigation)
                .FirstOrDefaultAsync(m => m.CodEmpleado == id);
            if (empleado == null)
            {
                return NotFound();
            }

            return View(empleado);
        }

        // GET: Empleado/Create
        public IActionResult Create()
        {
            ViewData["CodPuesto"] = new SelectList(_context.Puestos, "CodPuesto", "CodPuesto");
            return View();
        }

        // POST: Empleado/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodEmpleado,NombreEmpleado,TelefonoEmpleado,SueldoBase,NuevoSueldo,EstadoContrato,FechaContrato,EstadoEmpleado,FechaInicioContrato,EstadoAntiguedad,CodPuesto")] Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(empleado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CodPuesto"] = new SelectList(_context.Puestos, "CodPuesto", "CodPuesto", empleado.CodPuesto);
            return View(empleado);
        }

        // GET: Empleado/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Empleados == null)
            {
                return NotFound();
            }

            var empleado = await _context.Empleados.FindAsync(id);
            if (empleado == null)
            {
                return NotFound();
            }
            ViewData["CodPuesto"] = new SelectList(_context.Puestos, "CodPuesto", "CodPuesto", empleado.CodPuesto);
            return View(empleado);
        }

        // POST: Empleado/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CodEmpleado,NombreEmpleado,TelefonoEmpleado,SueldoBase,NuevoSueldo,EstadoContrato,FechaContrato,EstadoEmpleado,FechaInicioContrato,EstadoAntiguedad,CodPuesto")] Empleado empleado)
        {
            if (id != empleado.CodEmpleado)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(empleado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmpleadoExists(empleado.CodEmpleado))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CodPuesto"] = new SelectList(_context.Puestos, "CodPuesto", "CodPuesto", empleado.CodPuesto);
            return View(empleado);
        }

        // GET: Empleado/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Empleados == null)
            {
                return NotFound();
            }

            var empleado = await _context.Empleados
                .Include(e => e.CodPuestoNavigation)
                .FirstOrDefaultAsync(m => m.CodEmpleado == id);
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
            if (_context.Empleados == null)
            {
                return Problem("Entity set 'DbEmpleadosContext.Empleados'  is null.");
            }
            var empleado = await _context.Empleados.FindAsync(id);
            if (empleado != null)
            {
                _context.Empleados.Remove(empleado);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmpleadoExists(int id)
        {
          return (_context.Empleados?.Any(e => e.CodEmpleado == id)).GetValueOrDefault();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> empleadoEmpresa()
        {

            try
            {

                var detalle = await _context.Contratos
                    .Include(m => m.CodEmpleadoNavigation)
                    .Include(m => m.CodEmpresaNavigation)
                    .ToListAsync();


                return new ViewAsPdf("reporteEmpleado", detalle)
                    {
                        //FileName = "prueba.pdf",
                        PageOrientation = Rotativa.AspNetCore.Options.Orientation.Portrait,
                        PageSize = Rotativa.AspNetCore.Options.Size.Letter
                    };
                


            }
            catch (Exception ex)
            {
                throw;
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> listaEmpresas()
        {

            try
            {

                var detalle = await _context.Contienes
                    .Include(m => m.CodDepartamentoNavigation)
                    .Include(m => m.CodEmpresaNavigation)
                    .Include(m => m.CodPuestoNavigation)
                    .ThenInclude(m => m.Empleados)
                    .ToListAsync();

                return new ViewAsPdf("listaEmpresas2", detalle)
                {
                    //FileName = "prueba.pdf",
                    PageOrientation = Rotativa.AspNetCore.Options.Orientation.Portrait,
                    PageSize = Rotativa.AspNetCore.Options.Size.Letter
                };



            }
            catch (Exception ex)
            {
                throw;
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> listaEmpresas1()
        {

            try
            {

                var detalle = await _context.Empresas
                    .Include(m => m.Contienes)
                    .ThenInclude(m => m.CodPuestoNavigation)
                    .Include(m => m.Contratos)
                    .ThenInclude(m => m.CodEmpleadoNavigation)
                    .ToListAsync();

                return new ViewAsPdf("listaEmpresas", detalle)
                {
                    //FileName = "prueba.pdf",
                    PageOrientation = Rotativa.AspNetCore.Options.Orientation.Portrait,
                    PageSize = Rotativa.AspNetCore.Options.Size.Letter
                };



            }
            catch (Exception ex)
            {
                throw;
            }
        }



        // GET: Empleado/Create
        public IActionResult contratos1()
        {
            ViewData["CodEmpleado"] = new SelectList(_context.Empleados, "CodEmpleado", "NombreEmpleado");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> contratos1(int? CodEmpleado)
        {

            if (CodEmpleado == null)
            {
                return NotFound();
            }

            try
            {

                var detalle = await _context.Empleados
                    .Include(m => m.CodPuestoNavigation)
                    .Include(m => m.Contratos)
                    .ThenInclude(m=> m.CodEmpresaNavigation)
                    .Include(m => m.HistorialIncrementos)
                    .FirstOrDefaultAsync(m => m.CodEmpleado == CodEmpleado);

                return new ViewAsPdf("contratos", detalle)
                {
                    //FileName = "prueba.pdf",
                    PageOrientation = Rotativa.AspNetCore.Options.Orientation.Portrait,
                    PageSize = Rotativa.AspNetCore.Options.Size.Letter
                };



            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
