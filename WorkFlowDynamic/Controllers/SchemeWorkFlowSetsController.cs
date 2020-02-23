    using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WorkFlowDynamic.DataEntityTypes;
using WorkFlowDynamic.Models;

namespace WorkFlowDynamic.Controllers
{
    public class SchemeWorkFlowSetsController : Controller
    {
        private readonly WorkflowdynamicContext _context;
        private readonly WorkFlowServices _serviceFlow = new WorkFlowServices();

        public SchemeWorkFlowSetsController(WorkflowdynamicContext context)
        {
            _context = context;
        }

        // GET: SchemeWorkFlowSets
        public async Task<IActionResult> Index()
        {
            return View(await _context.SchemeWorkFlowSet.ToListAsync());
        }

        // GET: SchemeWorkFlowSets/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var schemeWorkFlowSet = await _context.SchemeWorkFlowSet
                .FirstOrDefaultAsync(m => m.Id == id);
            if (schemeWorkFlowSet == null)
            {
                return NotFound();
            }

            return View(schemeWorkFlowSet);
        }

        // GET: SchemeWorkFlowSets/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SchemeWorkFlowSets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SchemeName,state")] SchemeWorkFlowSet schemeWorkFlowSet)
        {
            if (ModelState.IsValid)
            {
                HttpContext.Session.SetString("name", schemeWorkFlowSet.SchemeName);
                _context.Add(schemeWorkFlowSet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(schemeWorkFlowSet);
        }

        // GET: SchemeWorkFlowSets/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var schemeWorkFlowSet = await _context.SchemeWorkFlowSet.FindAsync(id);
            if (schemeWorkFlowSet == null)
            {
                return NotFound();
            }
            return View(schemeWorkFlowSet);
        }

        // POST: SchemeWorkFlowSets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,SchemeName,state")] SchemeWorkFlowSet schemeWorkFlowSet)
        {
            if (id != schemeWorkFlowSet.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(schemeWorkFlowSet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SchemeWorkFlowSetExists(schemeWorkFlowSet.Id))
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
            return View(schemeWorkFlowSet);
        }

        // GET: SchemeWorkFlowSets/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var schemeWorkFlowSet = await _context.SchemeWorkFlowSet
                .FirstOrDefaultAsync(m => m.Id == id);
            if (schemeWorkFlowSet == null)
            {
                return NotFound();
            }

            return View(schemeWorkFlowSet);
        }

        // POST: SchemeWorkFlowSets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var schemeWorkFlowSet = await _context.SchemeWorkFlowSet.FindAsync(id);
            _context.SchemeWorkFlowSet.Remove(schemeWorkFlowSet);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SchemeWorkFlowSetExists(long id)
        {
            return _context.SchemeWorkFlowSet.Any(e => e.Id == id);
        }
    }
}
