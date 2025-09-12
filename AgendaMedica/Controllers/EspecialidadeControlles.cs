using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AgendaMedica.Data;
using AgendaMedica.Models;

namespace AgendaMedica.Controllers
{
    public class EspecialidadeControlles : Controller
    {
        private readonly ApplicationDbContext _context;

        public EspecialidadeControlles(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EspecialidadeControlles
        public async Task<IActionResult> Index()
        {
            return View(await _context.Especialidades.ToListAsync());
        }

        // GET: EspecialidadeControlles/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var especialidade = await _context.Especialidades
                .FirstOrDefaultAsync(m => m.EspecialidadeId == id);
            if (especialidade == null)
            {
                return NotFound();
            }

            return View(especialidade);
        }

        // GET: EspecialidadeControlles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EspecialidadeControlles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EspecialidadeId,Nome")] Especialidade especialidade)
        {
            if (ModelState.IsValid)
            {
                especialidade.EspecialidadeId = Guid.NewGuid();
                _context.Add(especialidade);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(especialidade);
        }

        // GET: EspecialidadeControlles/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var especialidade = await _context.Especialidades.FindAsync(id);
            if (especialidade == null)
            {
                return NotFound();
            }
            return View(especialidade);
        }

        // POST: EspecialidadeControlles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("EspecialidadeId,Nome")] Especialidade especialidade)
        {
            if (id != especialidade.EspecialidadeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(especialidade);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EspecialidadeExists(especialidade.EspecialidadeId))
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
            return View(especialidade);
        }

        // GET: EspecialidadeControlles/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var especialidade = await _context.Especialidades
                .FirstOrDefaultAsync(m => m.EspecialidadeId == id);
            if (especialidade == null)
            {
                return NotFound();
            }

            return View(especialidade);
        }

        // POST: EspecialidadeControlles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var especialidade = await _context.Especialidades.FindAsync(id);
            if (especialidade != null)
            {
                _context.Especialidades.Remove(especialidade);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EspecialidadeExists(Guid id)
        {
            return _context.Especialidades.Any(e => e.EspecialidadeId == id);
        }
    }
}
