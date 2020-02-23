using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WorkFlowDynamic.Models;

namespace WorkFlowDynamic.Controllers
{
    public class WorkflowController : Controller
    {
        public WorkflowController()
        {
        }

        // ReSharper disable once InconsistentNaming
        protected readonly static string defaultAction = "Create";

        /// <summary>
        ///   Adds the step heading an title information
        /// </summary>
        /// <param name="workflowFileName">The workflow fileName</param>
        /// <param name="stepIdentifier">The step identifier</param>

        public SchemeStepFlowModel GetCurrentStep(int stepIdentifier, List<SchemeStepFlowModel> schemes)
        {
            SchemeStepFlowModel step = new SchemeStepFlowModel();
            var stepFlow = schemes.FirstOrDefault(s => s.Ordre == stepIdentifier.ToString());
            step.Gestionnaire = stepFlow.Gestionnaire ?? ControllerContext.RouteData.Values["controller"].ToString();
            step.Service = stepFlow.Service ?? ControllerContext.RouteData.Values["action"].ToString();
            step.Ordre = stepIdentifier.ToString();

            return step;
        }


        public RedirectToActionResult LoadNextStep(List<SchemeStepFlowModel> workflowName, int stepIdentifier)
        {
            SchemeStepFlowModel step = GetNextStep(workflowName, stepIdentifier);
            var nbrStepTotal =  Convert.ToInt32(HttpContext.Session.Get<int>("WorkFlowNumberStep"));
            var currentStep = Convert.ToInt32(HttpContext.Session.Get<string>("StepIdentifier"));
            //if the next step is found
            if (step != null && !string.IsNullOrWhiteSpace(step.Service) && !string.IsNullOrWhiteSpace(step.Gestionnaire))
            {
                //If we must skip this step
                if (IsStepToSkip(step))
                {
                    //Load the next step
                    HttpContext.Session.Set<string>("StepIdentifier", step.Ordre);
                    return LoadNextStep(workflowName, Convert.ToInt32(step.Ordre));
                }
                else
                {
                    // ReSharper disable once RedundantAnonymousTypePropertyName
                    HttpContext.Session.Set<string>("StepIdentifier", step.Ordre);
                    return RedirectToAction(step.Service, step.Gestionnaire, new { workflowName = workflowName, stepIdentifier = ++stepIdentifier });
                }
            }
            else if (Convert.ToInt32(HttpContext.Session.Get<int>("WorkFlowNumberStep")) == Convert.ToInt32(HttpContext.Session.Get<string>("StepIdentifier")))
            {
                // ReSharper disable once RedundantAnonymousTypePropertyName
                return RedirectToAction("Index", "Home", new { workflowName = workflowName, stepIdentifier = stepIdentifier });
            }
            else//if not
            {
                // ReSharper disable once RedundantAnonymousTypePropertyName
                return RedirectToAction(defaultAction, new { workflowName = workflowName, stepIdentifier = stepIdentifier });
            }
        }


        public virtual ActionResult PreviousPage()
        {
            return LoadPreviousStep(HttpContext.Session.Get<List<SchemeStepFlowModel>>("WorkFlow"), Convert.ToInt32(HttpContext.Session.Get<string>("StepIdentifier")));
        }

        public RedirectToActionResult LoadPreviousStep(List<SchemeStepFlowModel> workflowName, int stepIdentifier)
        {
            //If the page is in a workflow
            if (!defaultAction.Equals(workflowName))
            {
                SchemeStepFlowModel step = GetPreviousStep(workflowName, stepIdentifier);

                //if the previous step is found
                if (!string.IsNullOrWhiteSpace(step.Service) && !string.IsNullOrWhiteSpace(step.Gestionnaire) && !defaultAction.Equals(workflowName))
                {
                    //if we must skip this step
                    if (IsStepToSkip(step))
                    {
                        //Load the previous step.(This can result in an infinite loop)
                        return LoadPreviousStep(workflowName, Convert.ToInt32(step.Ordre));
                    }
                    else
                    {
                        // ReSharper disable once RedundantAnonymousTypePropertyName
                        return RedirectToAction(step.Service, step.Gestionnaire, new { workflowName = workflowName, stepIdentifier = (stepIdentifier > 1) ? --stepIdentifier : stepIdentifier });
                    }
                }
                else//if not
                {
                    // ReSharper disable once RedundantAnonymousTypePropertyName
                    return RedirectToAction(defaultAction, new { workflowName = workflowName, stepIdentifier = (stepIdentifier > 1) ? --stepIdentifier : stepIdentifier });
                }
            }
            else//if not
            {
                return RedirectToAction(defaultAction);
            }
        }


        private SchemeStepFlowModel GetNextStep(List<SchemeStepFlowModel> workflowFileName, int stepIdentifier)
        {
            return new WorkFlowServices().GetNextStep(workflowFileName, stepIdentifier);
        }


        private SchemeStepFlowModel GetPreviousStep(List<SchemeStepFlowModel> workflowFileName, int stepIdentifier)
        {
            return new WorkFlowServices().GetPreviousStep(workflowFileName, stepIdentifier);
        }

        public SchemeStepFlowModel GetStep(List<SchemeStepFlowModel> workflowFileName, string stepIdentifier)
        {
            return new WorkFlowServices().GetStep(workflowFileName, Convert.ToInt32(stepIdentifier));
        }

        public SchemeStepFlowModel GetStep(int stepIndex)
        {
            return new SchemeStepFlowModel();
        }

        //public Workflow GetWorkflow(string workflowFileName)
        //{
        //    return new WorkflowServices().GetWorkflow(workflowFileName);
        //}

        public void AddStepToSkip(SchemeStepFlowModel step)
        {
            if (!(HttpContext.Session.Get<List<SchemeStepFlowModel>>("StepsToSkip") is List<SchemeStepFlowModel>))
            {
                HttpContext.Session.Set<List<SchemeStepFlowModel>>("StepsToSkip", new List<SchemeStepFlowModel>());
            }

            //Find if the step is alraedy in the list
            int stepOccurenceCount = HttpContext.Session.Get<List<SchemeStepFlowModel>>("StepsToSkip")
                .Count(s => s.Service == step.Service && s.Gestionnaire == step.Gestionnaire);

            //If the step is not already in the list
            if (stepOccurenceCount == 0)
            {
                HttpContext.Session.Get<List<SchemeStepFlowModel>>("StepsToSkip").Add(step);
            }
        }

        public void RemoveStepToSkip(SchemeStepFlowModel step)
        {
            if (HttpContext.Session.Get<List<SchemeStepFlowModel>>("StepsToSkip") is List<SchemeStepFlowModel>)
            {
                //Remove the step from the list
                HttpContext.Session.Set<List<SchemeStepFlowModel>>("StepsToSkip", HttpContext.Session.Get<List<SchemeStepFlowModel>>("StepsToSkip")
                    .Except((HttpContext.Session.Get<List<SchemeStepFlowModel>>("StepsToSkip")
                            .Where(s => s.Service == step.Service && s.Gestionnaire == step.Gestionnaire))
                    // ReSharper disable once RedundantTypeArgumentsOfMethod
                    ).ToList<SchemeStepFlowModel>());
            }
        }

        public bool IsStepToSkip(SchemeStepFlowModel step)
        {
            if (HttpContext.Session.Get<List<SchemeStepFlowModel>>("StepsToSkip") is List<SchemeStepFlowModel>)
            {
                return (HttpContext.Session.Get<List<SchemeStepFlowModel>>("StepsToSkip") as List<SchemeStepFlowModel>)
                    .Any(s => s.Service == step.Service && s.Gestionnaire == step.Gestionnaire);
            }

            return false;
        }


        protected ActionResult RedirectToLocal(String returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }
    }
}