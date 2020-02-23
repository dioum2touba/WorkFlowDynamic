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
    public class TypeOperationsController : WorkflowController
    {
        private readonly WorkflowdynamicContext _context;
        private readonly WorkFlowServices _serviceFlow = new WorkFlowServices();

        public TypeOperationsController(WorkflowdynamicContext context)
        {
            _context = context;
        }

        // GET: TypeOperations
        public async Task<IActionResult> Index()
        {
            return View(await _context.TypeOperation.ToListAsync());
        }

        // GET: TypeOperations/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeOperation = await _context.TypeOperation
                .FirstOrDefaultAsync(m => m.Id == id);
            if (typeOperation == null)
            {
                return NotFound();
            }

            return View(typeOperation);
        }

        // GET: TypeOperations/Create
        public IActionResult Create()
        {
            ViewBag.Activity = _serviceFlow.GetStep(HttpContext.Session.Get<List<SchemeStepFlowModel>>("WorkFlow"), Convert.ToInt32(HttpContext.Session.Get<string>("StepIdentifier"))).Activity;
            return View();
        }

        // POST: TypeOperations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Label,Description,Status")] TypeOperation typeOperation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(typeOperation);
                await _context.SaveChangesAsync();
                //var step = Convert.ToInt32(HttpContext.Session.Get<string>("StepIdentifier") + 1);
                //HttpContext.Session.Set<string>("StepIdentifier", step.ToString());
                return LoadNextStep(HttpContext.Session.Get<List<SchemeStepFlowModel>>("WorkFlow"), Convert.ToInt32(HttpContext.Session.Get<string>("StepIdentifier")));
            }
            return View(typeOperation);
        }

        // GET: TypeOperations/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeOperation = await _context.TypeOperation.FindAsync(id);
            if (typeOperation == null)
            {
                return NotFound();
            }
            return View(typeOperation);
        }

        // POST: TypeOperations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Label,Description,Status")] TypeOperation typeOperation)
        {
            if (id != typeOperation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(typeOperation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TypeOperationExists(typeOperation.Id))
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
            return View(typeOperation);
        }

        // GET: TypeOperations/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeOperation = await _context.TypeOperation
                .FirstOrDefaultAsync(m => m.Id == id);
            if (typeOperation == null)
            {
                return NotFound();
            }

            return View(typeOperation);
        }

        // POST: TypeOperations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var typeOperation = await _context.TypeOperation.FindAsync(id);
            _context.TypeOperation.Remove(typeOperation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TypeOperationExists(long id)
        {
            return _context.TypeOperation.Any(e => e.Id == id);
        }
    }
}
