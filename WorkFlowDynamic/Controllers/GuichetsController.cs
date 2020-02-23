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
    public class GuichetsController : WorkflowController
    {
        private readonly WorkflowdynamicContext _context;
        private readonly WorkFlowServices _serviceFlow = new WorkFlowServices();

        public GuichetsController(WorkflowdynamicContext context)
        {
            _context = context;
        }

        // GET: Guichets
        public async Task<IActionResult> Index()
        {
            return View(await _context.Guichet.ToListAsync());
        }

        // GET: Guichets/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guichet = await _context.Guichet
                .FirstOrDefaultAsync(m => m.Id == id);
            if (guichet == null)
            {
                return NotFound();
            }

            return View(guichet);
        }

        // GET: Guichets/Create
        public IActionResult Create()
        {
            ViewBag.Activity = _serviceFlow.GetStep(HttpContext.Session.Get<List<SchemeStepFlowModel>>("WorkFlow"), Convert.ToInt32(HttpContext.Session.Get<string>("StepIdentifier"))).Activity;
            return View();
        }

        // POST: Guichets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Label,Code")] Guichet guichet)
        {
            if (ModelState.IsValid)
            {
                _context.Add(guichet);
                await _context.SaveChangesAsync();
                //var step = Convert.ToInt32(HttpContext.Session.Get<string>("StepIdentifier") + 1);
                //HttpContext.Session.Set<string>("StepIdentifier", step.ToString());
                return LoadNextStep(HttpContext.Session.Get<List<SchemeStepFlowModel>>("WorkFlow"), Convert.ToInt32(HttpContext.Session.Get<string>("StepIdentifier")));
            }
            return View(guichet);
        }

        // GET: Guichets/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guichet = await _context.Guichet.FindAsync(id);
            if (guichet == null)
            {
                return NotFound();
            }
            return View(guichet);
        }

        // POST: Guichets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Label,Code")] Guichet guichet)
        {
            if (id != guichet.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(guichet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GuichetExists(guichet.Id))
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
            return View(guichet);
        }

        // GET: Guichets/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guichet = await _context.Guichet
                .FirstOrDefaultAsync(m => m.Id == id);
            if (guichet == null)
            {
                return NotFound();
            }

            return View(guichet);
        }

        // POST: Guichets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var guichet = await _context.Guichet.FindAsync(id);
            _context.Guichet.Remove(guichet);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GuichetExists(long id)
        {
            return _context.Guichet.Any(e => e.Id == id);
        }
    }
}
