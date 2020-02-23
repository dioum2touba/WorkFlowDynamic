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
    public class ServicesController : WorkflowController
    {
        private readonly WorkflowdynamicContext _context;
        private readonly WorkFlowServices _serviceFlow = new WorkFlowServices();

        public ServicesController(WorkflowdynamicContext context)
        {
            _context = context;
        }

        // GET: Services
        public async Task<IActionResult> Index()
        {
            return View(await _context.Service.ToListAsync());
        }

        // GET: Services/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var service = await _context.Service
                .FirstOrDefaultAsync(m => m.Id == id);
            if (service == null)
            {
                return NotFound();
            }

            return View(service);
        }

        // GET: Services/Create
        public IActionResult Create()
        {
            ViewBag.title = _serviceFlow.GetStep(HttpContext.Session.Get<List<SchemeStepFlowModel>>("WorkFlow"), Convert.ToInt32(HttpContext.Session.Get<string>("StepIdentifier"))).Activity;
            return View();
        }

        // POST: Services/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NomService,Description")] Service service)
        {
            if (ModelState.IsValid)
            {
                _context.Add(service);
                await _context.SaveChangesAsync();
                //var step = Convert.ToInt32(HttpContext.Session.Get<string>("StepIdentifier") + 1);
                //HttpContext.Session.Set<string>("StepIdentifier", step.ToString());
                return LoadNextStep(HttpContext.Session.Get<List<SchemeStepFlowModel>>("WorkFlow"), Convert.ToInt32(HttpContext.Session.Get<string>("StepIdentifier")));
            }
            return View(service);
        }

        // GET: Services/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var service = await _context.Service.FindAsync(id);
            if (service == null)
            {
                return NotFound();
            }
            return View(service);
        }

        // POST: Services/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,NomService,Description")] Service service)
        {
            if (id != service.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(service);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServiceExists(service.Id))
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
            return View(service);
        }

        // GET: Services/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var service = await _context.Service
                .FirstOrDefaultAsync(m => m.Id == id);
            if (service == null)
            {
                return NotFound();
            }

            return View(service);
        }

        // POST: Services/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var service = await _context.Service.FindAsync(id);
            _context.Service.Remove(service);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ServiceExists(long id)
        {
            return _context.Service.Any(e => e.Id == id);
        }
    }
}
