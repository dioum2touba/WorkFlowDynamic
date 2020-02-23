using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WorkFlowDynamic.Models;

namespace WorkFlowDynamic.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly WorkflowdynamicContext _context;
        private readonly WorkFlowServices _serviceFlow = new WorkFlowServices();
        private List<ControleurModels> controleurs = null;

        public HomeController(ILogger<HomeController> logger, WorkflowdynamicContext context)
        {
            _logger = logger;
            _context = context;
            controleurs = new List<ControleurModels>();
            controleurs = _serviceFlow.CopyMasterData();
        }

        public IActionResult Index()
        {
            return View(_context.SchemeWorkFlowSet.ToList());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult DemarrerWorkflow(long? id)
        {
            var workflow = _serviceFlow.LoadWorkFlow(controleurs, id);
            HttpContext.Session.Set<List<SchemeStepFlowModel>>("WorkFlow", workflow);
            HttpContext.Session.Set<string>("StepIdentifier", "0");
            return LoadNextStep(HttpContext.Session.Get<List<SchemeStepFlowModel>>("WorkFlow"), Convert.ToInt32(HttpContext.Session.Get<string>("StepIdentifier")));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public RedirectToActionResult LoadNextStep(List<SchemeStepFlowModel> workflowName, int stepIdentifier)
        {
            var defaultAction = workflowName.FirstOrDefault(w => w.Ordre == stepIdentifier.ToString());
            //If the page is in a workflow
            if (workflowName!= null && workflowName.Count>0)
            {
                 SchemeStepFlowModel step = _serviceFlow.GetNextStep(workflowName, stepIdentifier);
               // return LoadNextStep(workflowName, Convert.ToInt32(stepIdentifier));
                return RedirectToAction(step.Service, step.Gestionnaire);
            }
            else//if not
            {
                return RedirectToAction(defaultAction.Service, defaultAction.Gestionnaire);
            }
        }

        
    }
}
