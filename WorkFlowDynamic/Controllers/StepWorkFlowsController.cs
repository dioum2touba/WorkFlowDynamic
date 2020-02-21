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
using WorkFlowDynamic.Services;

namespace WorkFlowDynamic.Controllers
{
    public class StepWorkFlowsController : Controller
    {
        private readonly WorkflowdynamicContext _context; 
        private readonly WorkFlowServices _serviceFlow = new WorkFlowServices();
        private List<ControleurModels> controleurs = null;

        public StepWorkFlowsController(WorkflowdynamicContext context)
        {
            _context = context;
            controleurs = new List<ControleurModels>();
            controleurs = _serviceFlow.CopyMasterData();
        }

        // GET: StepWorkFlows
        public async Task<IActionResult> Index()
        {
            return View(await _context.StepWorkFlowSet.ToListAsync());
        }

        // GET: StepWorkFlows/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stepWorkFlowSet = await _context.StepWorkFlowSet
                .FirstOrDefaultAsync(m => m.Id == id);
            if (stepWorkFlowSet == null)
            {
                return NotFound();
            }

            return View(stepWorkFlowSet);
        }

        // GET: StepWorkFlows/Create
        public IActionResult Create(long? id)
        {
            ViewBag.SchemeName = _context.SchemeWorkFlowSet.FirstOrDefault().SchemeName;
            ViewBag.controleurs = GetDataControllers(controleurs);
            ViewBag.services = GetDataActions(controleurs);
            var name = HttpContext.Session.GetString("name");
            return View();
        }

        public List<SelectListItem> GetDataActions(List<ControleurModels> controleurs)
        {
            List<SelectListItem> values = new List<SelectListItem>();
            values.Add(new SelectListItem { Value = "Sélectionner", Text = "Sélectionner" });
            foreach (var elt in controleurs)
            {
                values.Add(new SelectListItem { Value = elt.Action, Text = elt.Description });
            }
            return values;
        }

        public List<SelectListItem> GetDataControllers(List<ControleurModels> controleurs)
        {
            List<SelectListItem> values = new List<SelectListItem>();
            values.Add(new SelectListItem { Value = "Sélectionner", Text = "Sélectionner" });
            foreach (var elt in controleurs)
            {
                values.Add(new SelectListItem { Value = elt.Controller, Text = elt.DetailsControleurs });
            }
            return values;
        }

        [HttpGet]
        public IActionResult GetDataActionSelected(string controllerSelected)
        {
            var lists = controleurs.Where(c => c.Controller == controllerSelected).ToList();
            return Ok(lists);
        }

        [HttpPost]
        public IActionResult GarderActivities([FromBody] StepFlowModel flowModel)
        {
           // StepFlowModel flowModel = new StepFlowModel() { Controller = controleur, Action = servcice };
            var lists = HttpContext.Session.Get<List<StepFlowModel>>("StepWorkFlow") ?? new List<StepFlowModel>();
            lists.Add(flowModel);
            HttpContext.Session.Set<List<StepFlowModel>>("StepWorkFlow", lists);
            // Requires you add the Set and Get extension method mentioned in the topic.
            return Ok(lists);
        }

        // POST: StepWorkFlows/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Controller,Action")] StepWorkFlowSet stepWorkFlowSet)
        {
            if (ModelState.IsValid)
            {
                _context.Add(stepWorkFlowSet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(stepWorkFlowSet);
        }

        // GET: StepWorkFlows/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stepWorkFlowSet = await _context.StepWorkFlowSet.FindAsync(id);
            if (stepWorkFlowSet == null)
            {
                return NotFound();
            }
            return View(stepWorkFlowSet);
        }

        // POST: StepWorkFlows/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [System.Web.Mvc.ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Controller,Action")] StepWorkFlowSet stepWorkFlowSet)
        {
            if (id != stepWorkFlowSet.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stepWorkFlowSet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StepWorkFlowSetExists(stepWorkFlowSet.Id))
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
            return View(stepWorkFlowSet);
        }

        // GET: StepWorkFlows/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stepWorkFlowSet = await _context.StepWorkFlowSet
                .FirstOrDefaultAsync(m => m.Id == id);
            if (stepWorkFlowSet == null)
            {
                return NotFound();
            }

            return View(stepWorkFlowSet);
        }

        // POST: StepWorkFlows/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var stepWorkFlowSet = await _context.StepWorkFlowSet.FindAsync(id);
            _context.StepWorkFlowSet.Remove(stepWorkFlowSet);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StepWorkFlowSetExists(long id)
        {
            return _context.StepWorkFlowSet.Any(e => e.Id == id);
        }
    }
}
