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
        public IActionResult Index(long? id)
        {
            var schemeWorkFlow = _context.SchemeWorkFlowSet.Where(s => s.Id == id).FirstOrDefault();
            HttpContext.Session.Set<SchemeWorkFlowSet>("SchemeWorkFlow", schemeWorkFlow);
            HttpContext.Session.Set<string>("StepWorkFlowsPage", "Index");
            ViewBag.SchemeName = schemeWorkFlow.SchemeName;
            ViewBag.SchemeId = schemeWorkFlow.Id;
            ViewBag.controleurs = GetDataControllers(controleurs);
            ViewBag.services = GetDataActions(controleurs);
            var list = _serviceFlow.GetSchemeStepFlowModel(schemeWorkFlow, controleurs);
            HttpContext.Session.Set<List<SchemeStepFlowModel>>("SchemeStepFlowModel", list);
            return View(new StepWorkFlowSet());
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
            var schemeWorkFlow = _context.SchemeWorkFlowSet.Where(s => s.Id == id).FirstOrDefault();
            ViewBag.SchemeName = schemeWorkFlow.SchemeName;
            HttpContext.Session.Set<string>("StepWorkFlowsPage", "Create");
            // StepFlowModel flowModel = new StepFlowModel() { Controller = controleur, Action = servcice };
            HttpContext.Session.Set<SchemeWorkFlowSet>("SchemeWorkFlow", schemeWorkFlow);
            ViewBag.controleurs = GetDataControllers(controleurs);
            ViewBag.services = GetDataActions(controleurs);
            var name = HttpContext.Session.GetString("name");
            return View();
        }

        #region Filtrer Liste des descriptions des Actions et Controller
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
        #endregion

        #region Recupérer l'objet sélectionné depuis la vue
        [HttpGet]
        public IActionResult GetDataActionSelected(string controllerSelected)
        {
            var lists = controleurs.Where(c => c.Controller == controllerSelected).ToList();
            return Ok(lists);
        }
        #endregion

        #region Garder une activité choisie dans la session
        [HttpPost]
        public IActionResult GarderActivities([FromBody] StepFlowModel flowModel)
        {
            var page = HttpContext.Session.Get<string>("StepWorkFlowsPage");
            if (page == "Create")
            {
                var lists = HttpContext.Session.Get<List<StepFlowModel>>("StepWorkFlow") ?? new List<StepFlowModel>();
                var nbre = lists.Count + 1;
                flowModel.id = nbre + "";
                lists.Add(flowModel);
                HttpContext.Session.Set<List<StepFlowModel>>("StepWorkFlow", lists);
                // Requires you add the Set and Get extension method mentioned in the topic.
                return Ok(lists);
            }
            else
            {
                SchemeStepFlowModel schemeStepFlow = new SchemeStepFlowModel()
                {
                    Activity = flowModel.activity,
                    Gestionnaire = flowModel.cible,
                    Service = flowModel.service,
                    Occurence = 1
                };
                var lists = HttpContext.Session.Get<List<SchemeStepFlowModel>>("SchemeStepFlowModel") ?? new List<SchemeStepFlowModel>();
                var nbre = lists.Count + 1;
                schemeStepFlow.Ordre = nbre + "";
                lists.Add(schemeStepFlow);
                HttpContext.Session.Set<List<SchemeStepFlowModel>>("SchemeStepFlowModel", lists);
                // Requires you add the Set and Get extension method mentioned in the topic.
                return Ok(lists);
            }
        }
        #endregion

        #region Supprimer une activité choisie dans la session
        [HttpGet]
        public IActionResult RemoveActivities(string setpFlowsId)
        {
            var page = HttpContext.Session.Get<string>("StepWorkFlowsPage");
            if (page == "Create")
            {
                var lists = HttpContext.Session.Get<List<StepFlowModel>>("StepWorkFlow") ?? new List<StepFlowModel>();
                lists.Remove(lists.FirstOrDefault(l => l.id == setpFlowsId));
                int nbre = 0;
                List<StepFlowModel> setpFlows = new List<StepFlowModel>();
                foreach (var elt in lists)
                {
                    nbre += 1;
                    elt.id = nbre + "";
                    setpFlows.Add(elt);
                }
                HttpContext.Session.Set<List<StepFlowModel>>("StepWorkFlow", setpFlows);
                return Ok(setpFlows);
            }
            else
            {
                var lists = HttpContext.Session.Get<List<SchemeStepFlowModel>>("SchemeStepFlowModel") ?? new List<SchemeStepFlowModel>();
                lists.Remove(lists.FirstOrDefault(l => l.Ordre == setpFlowsId));
                int nbre = 0;
                List<SchemeStepFlowModel> setpFlows = new List<SchemeStepFlowModel>();
                foreach (var elt in lists)
                {
                    nbre += 1;
                    elt.Ordre = nbre + "";
                    setpFlows.Add(elt);
                }
                HttpContext.Session.Set<List<SchemeStepFlowModel>>("SchemeStepFlowModel", setpFlows);
                return Ok(setpFlows);
            }
            
        }
        #endregion

        #region Enregistrer l'ordre des étapes du schéma
        [HttpPost]
        public IActionResult SaveOrderStepScheme(List<string> position)
        {
            HttpContext.Session.Set<List<string>>("positions", position);
            return Ok("Succes");
        }
        #endregion

        #region Recupérer les activités qui ont été déja choisie
        [HttpGet]
        public IActionResult GarderActivitiesLists()
        {
            var page = HttpContext.Session.Get<string>("StepWorkFlowsPage");
            if (page == "Index")
                return Ok(HttpContext.Session.Get<List<SchemeStepFlowModel>>("SchemeStepFlowModel") ?? new List<SchemeStepFlowModel>());
            else
                return Ok(HttpContext.Session.Get<List<StepFlowModel>>("StepWorkFlow") ?? new List<StepFlowModel>());
        }
        #endregion

        #region Enregistrer le schema dans la base de donnée
        [HttpGet]
        public IActionResult SaveSchemeInDatabase()
        {
            var page = HttpContext.Session.Get<string>("StepWorkFlowsPage");
            var schemeWorkFlow = HttpContext.Session.Get<SchemeWorkFlowSet>("SchemeWorkFlow");
            
            var orderStep = HttpContext.Session.Get<List<string>>("positions");
            if (page == "Index")
            {
                var listStep = HttpContext.Session.Get<List<SchemeStepFlowModel>>("SchemeStepFlowModel") ?? new List<SchemeStepFlowModel>();
                var listSheme = _serviceFlow.UpdateSchemeStepFlowModel(controleurs, listStep);
                _serviceFlow.UpdateSchemeInDatabase(schemeWorkFlow, listSheme, orderStep, page);
            }
            else
            {
                var listStep = HttpContext.Session.Get<List<StepFlowModel>>("StepWorkFlow") ?? new List<StepFlowModel>();
                _serviceFlow.SaveSchemeInDatabase(schemeWorkFlow, listStep, orderStep, page);
            }
            HttpContext.Session.Set<List<StepFlowModel>>("StepWorkFlow", null);
            HttpContext.Session.Set<List<SchemeStepFlowModel>>("SchemeStepFlowModel", null);
            return Ok();
        }
        #endregion

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
