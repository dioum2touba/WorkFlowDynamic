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
    public class AgencesController : WorkflowController
    {
        private readonly WorkflowdynamicContext _context;
        private readonly WorkFlowServices _serviceFlow = new WorkFlowServices();

        public AgencesController(WorkflowdynamicContext context)
        {
            _context = context;
        }

        // GET: Agences
        public async Task<IActionResult> Index()
        {
            return View(await _context.Agence.ToListAsync());
        }

        // GET: Agences/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agence = await _context.Agence
                .FirstOrDefaultAsync(m => m.Id == id);
            if (agence == null)
            {
                return NotFound();
            }

            return View(agence);
        }

        // GET: Agences/Create
        public IActionResult Create()
        {
            ViewBag.Activity = _serviceFlow.GetStep(HttpContext.Session.Get<List<SchemeStepFlowModel>>("WorkFlow"), Convert.ToInt32(HttpContext.Session.Get<string>("StepIdentifier"))).Activity;
            return View();
        }

        // POST: Agences/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NomAgence,Adresse,codeAgence,Pays,Region")] Agence agence)
        {
            if (ModelState.IsValid)
            {
                _context.Add(agence);
                await _context.SaveChangesAsync();
                //var step = Convert.ToInt32(HttpContext.Session.Get<string>("StepIdentifier")) + 1;
                //HttpContext.Session.Set<string>("StepIdentifier", step.ToString());
                return LoadNextStep(HttpContext.Session.Get<List<SchemeStepFlowModel>>("WorkFlow"), Convert.ToInt32(HttpContext.Session.Get<string>("StepIdentifier")));
            }
            return View(agence);
        }

        // GET: Agences/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agence = await _context.Agence.FindAsync(id);
            if (agence == null)
            {
                return NotFound();
            }
            return View(agence);
        }

        // POST: Agences/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,NomAgence,Adresse,codeAgence,Pays,Region")] Agence agence)
        {
            if (id != agence.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(agence);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AgenceExists(agence.Id))
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
            return View(agence);
        }

        // GET: Agences/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agence = await _context.Agence
                .FirstOrDefaultAsync(m => m.Id == id);
            if (agence == null)
            {
                return NotFound();
            }

            return View(agence);
        }

        // POST: Agences/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var agence = await _context.Agence.FindAsync(id);
            _context.Agence.Remove(agence);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AgenceExists(long id)
        {
            return _context.Agence.Any(e => e.Id == id);
        }
    }
}
