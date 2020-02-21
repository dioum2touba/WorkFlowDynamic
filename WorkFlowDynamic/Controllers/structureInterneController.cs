using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WorkFlowDynamic.DataEntityTypes;
using WorkFlowDynamic.Models;

namespace WorkFlowDynamic.Controllers
{
    public class structureInterneController : Controller
    {
        private readonly WorkflowdynamicContext _context;

        public structureInterneController(WorkflowdynamicContext context)
        {
            _context = context;
        }

        // GET: structureInterne
        public async Task<IActionResult> Index()
        {
            return View(await _context.structure_interne.ToListAsync());
        }

        // GET: structureInterne/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var structure_interne = await _context.structure_interne
                .FirstOrDefaultAsync(m => m.id == id);
            if (structure_interne == null)
            {
                return NotFound();
            }

            return View(structure_interne);
        }

        // GET: structureInterne/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: structureInterne/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,email,nom_structure,telephone")] structure_interne structure_interne)
        {
            if (ModelState.IsValid)
            {
                _context.Add(structure_interne);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(structure_interne);
        }

        // GET: structureInterne/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var structure_interne = await _context.structure_interne.FindAsync(id);
            if (structure_interne == null)
            {
                return NotFound();
            }
            return View(structure_interne);
        }

        // POST: structureInterne/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,email,nom_structure,telephone")] structure_interne structure_interne)
        {
            if (id != structure_interne.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(structure_interne);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!structure_interneExists(structure_interne.id))
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
            return View(structure_interne);
        }

        // GET: structureInterne/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var structure_interne = await _context.structure_interne
                .FirstOrDefaultAsync(m => m.id == id);
            if (structure_interne == null)
            {
                return NotFound();
            }

            return View(structure_interne);
        }

        // POST: structureInterne/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var structure_interne = await _context.structure_interne.FindAsync(id);
            _context.structure_interne.Remove(structure_interne);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool structure_interneExists(int id)
        {
            return _context.structure_interne.Any(e => e.id == id);
        }
    }
}
