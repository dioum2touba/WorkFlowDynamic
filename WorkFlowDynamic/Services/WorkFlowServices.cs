using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WorkFlowDynamic.DataEntityTypes;
using WorkFlowDynamic.Models;
using WorkFlowDynamic.Services;

namespace WorkFlowDynamic
{
    public class WorkFlowServices: IWorkFlowServices
    {
        private readonly WorkflowdynamicContext _context = new WorkflowdynamicContext();

        public List<ControleurModels> CopyMasterData()
        {
            var folderDetails = Path.Combine(Directory.GetCurrentDirectory(), $"{"Services.json"}");
            var JSON = File.ReadAllText(folderDetails);
            dynamic jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(JSON);
            List<ControleurModels> controleurLists = new List<ControleurModels>();
            foreach (var item in jsonObj["Controllers"])
            {
                controleurLists.Add(new ControleurModels()
                {
                    Action = item["Action"].ToString(),
                    Description = item["Description"].ToString(),
                    Controller = item["Controller"].ToString(),
                    DetailsControleurs = item["DetailsControleurs"].ToString()
                });
            }
            return controleurLists;
        }
        
        public void SaveSchemeInDatabase(SchemeWorkFlowSet schemeWorkFlow, List<StepFlowModel> listStep, List<string> orderStep, string page)
        {
            List<StepFlowModel> orderedList = null;
            // Ordonner d'abord la liste des activités le choix du User
            if (orderStep != null && orderStep.Count > 0)
                orderedList = OrderedActivities(listStep, orderStep);
            else
                orderedList = listStep;

            // Mise à jour de la liste pour ne pas enregistrer deux la liste
            var list = CheckIfStepFlowExists(orderedList);

            // Vider les anciens enregistrement du schema
            RemoveSchemeActivities(schemeWorkFlow);

            int step = 0;
            foreach (var elt in list)
            {
                step += 1;
                _context.Scheme_StepSet.Add(new Scheme_StepSet()
                {
                    StepWorkFlow = elt.Value,
                    //Numberstep = Convert.ToInt32(elt.ordre),
                    SchemeWorkFlowId = schemeWorkFlow.Id,
                    Activity = elt.Key,
                    Occurences = 1,
                    Numberstep = step
                });
            }
            _context.SaveChanges();
        }

        public void UpdateSchemeInDatabase(SchemeWorkFlowSet schemeWorkFlow, List<SchemeStepFlowModel> listStep, List<string> orderStep, string page)
        {
            // Ordonner d'abord la liste des activités le choix du User
            List<SchemeStepFlowModel> orderedList = null;
            // Ordonner d'abord la liste des activités le choix du User
            if (orderStep != null && orderStep.Count > 0)
                orderedList = UpdateOrderedActivities(listStep, orderStep);
            else
                orderedList = listStep;

           // UpdateSchemeStepFlowModel
            // Mise à jour de la liste pour ne pas enregistrer deux la liste
            var list = UpdateCheckIfStepFlowExists(orderedList);

            // Vider les anciens enregistrement du schema
            RemoveSchemeActivities(schemeWorkFlow);

            int step = 0;
            foreach (var elt in list)
            {
                step += 1;
                _context.Scheme_StepSet.Add(new Scheme_StepSet()
                {
                    StepWorkFlow = new StepWorkFlowSet() 
                    { Action = elt.Value.Service, Controller = elt.Value.Gestionnaire},
                    //Numberstep = Convert.ToInt32(elt.ordre),
                    SchemeWorkFlowId = schemeWorkFlow.Id,
                    Activity = elt.Key,
                    Occurences = 1,
                    Numberstep = step
                });
            }
            _context.SaveChanges();
        }

        #region Supprimer les anciennes activités du schéma
        public void RemoveSchemeActivities(SchemeWorkFlowSet schemeWork)
        {
            var listStepSheme = _context.Scheme_StepSet.Where(s => s.SchemeWorkFlowId == schemeWork.Id).ToList();
            _context.Scheme_StepSet.RemoveRange(listStepSheme);
            _context.SaveChanges();
        }
        #endregion

        #region Ordonner la liste des activités avant enregistrement de la liste
        public List<StepFlowModel> OrderedActivities(List<StepFlowModel> stepFlows, List<string> orderStep)
        {
            List<StepFlowModel> flowModels = new List<StepFlowModel>();
            foreach (var elt in orderStep)
            {
                flowModels.Add(stepFlows.FirstOrDefault(s => s.id == elt));
            }
            return flowModels;
        }
        #endregion 

        #region Ordonner la liste des activités avant enregistrement de la liste après mise à jour
        public List<SchemeStepFlowModel> UpdateOrderedActivities(List<SchemeStepFlowModel> listStep, List<string> orderStep)
        {
            List<SchemeStepFlowModel> flowModels = new List<SchemeStepFlowModel>();
            foreach (var elt in orderStep)
            {
                flowModels.Add(listStep.FirstOrDefault(s => s.Ordre == elt));
            }
            return flowModels;
        }
        #endregion 
        
        #region Mise des activités 
        public Dictionary<string, StepWorkFlowSet> CheckIfStepFlowExists(List<StepFlowModel> stepFlow)
        {
            Dictionary<string, StepWorkFlowSet> stepFlowsExisted = new Dictionary<string, StepWorkFlowSet>();
            Dictionary<string, StepWorkFlowSet> stepFlowsUnExisted = new Dictionary<string, StepWorkFlowSet>();
            var stepFlowsFromDB = _context.StepWorkFlowSet.ToList();

            foreach (var elt in stepFlow)
            {
                var step = stepFlowsFromDB.FirstOrDefault(s => s.Controller == elt.cible && s.Action == elt.service);
                if (step != null)
                    stepFlowsExisted.Add(elt.activity, step);
                else
                    stepFlowsExisted.Add(elt.activity, new StepWorkFlowSet()
                    {
                        Controller = elt.cible,
                        Action = elt.service
                    });
            }

            foreach (var elt in stepFlowsUnExisted)
                stepFlowsExisted.Add(elt.Key, elt.Value);

            return stepFlowsExisted;
        }
        #endregion

        #region Mise des activités après mise à jour
        public Dictionary<string, SchemeStepFlowModel> UpdateCheckIfStepFlowExists(List<SchemeStepFlowModel> stepFlow)
        {
            Dictionary<string, SchemeStepFlowModel> stepFlowsExisted = new Dictionary<string, SchemeStepFlowModel>();
            Dictionary<string, SchemeStepFlowModel> stepFlowsUnExisted = new Dictionary<string, SchemeStepFlowModel>();
            var stepFlowsFromDB = _context.StepWorkFlowSet.ToList();

            foreach (var elt in stepFlow)
            {
                var step = stepFlowsFromDB.FirstOrDefault(s => s.Controller == elt.Gestionnaire && s.Action == elt.Service);
                if (step != null)
                    stepFlowsExisted.Add(elt.Activity, new SchemeStepFlowModel() { Gestionnaire = step.Controller, Service = step.Action, id = step.Id+"" }); 
                else
                    stepFlowsExisted.Add(elt.Activity, new SchemeStepFlowModel()
                    {
                        Gestionnaire = elt.Gestionnaire,
                        Service = elt.Service,
                        id = elt.id
                    });
            }

            foreach (var elt in stepFlowsUnExisted)
                stepFlowsExisted.Add(elt.Key, elt.Value);

            return stepFlowsExisted;
        }
        #endregion

        public List<SchemeStepFlowModel> GetSchemeStepFlowModel(SchemeWorkFlowSet scheme, List<ControleurModels> controleurs)
        {
            var stepScheme = _context.Scheme_StepSet.Where(s => s.SchemeWorkFlowId == scheme.Id).ToList();
            var steps = _context.StepWorkFlowSet.Where(s => stepScheme.Select(s => s.StepWorkFlowId).Contains(s.Id)).ToList();
            List<SchemeStepFlowModel> schemeStepFlowModels = new List<SchemeStepFlowModel>();

            foreach (var elt in steps)
            {
                schemeStepFlowModels.Add(new SchemeStepFlowModel()
                {
                    Activity = stepScheme.FirstOrDefault(s => s.StepWorkFlowId == elt.Id).Activity,
                    Occurence = stepScheme.FirstOrDefault(s => s.StepWorkFlowId == elt.Id).Occurences,
                    Ordre = stepScheme.FirstOrDefault(s => s.StepWorkFlowId == elt.Id).Numberstep + "",
                    DetailsControleurs = controleurs.FirstOrDefault(c => c.Controller == elt.Controller && c.Action == elt.Action).DetailsControleurs,
                    Description = controleurs.FirstOrDefault(c => c.Controller == elt.Controller && c.Action == elt.Action).Description,
                    Gestionnaire = elt.Controller,
                    Service = elt.Action
                });
            }
            return schemeStepFlowModels;
        }

        public List<SchemeStepFlowModel> UpdateSchemeStepFlowModel(List<ControleurModels> controleurs, List<SchemeStepFlowModel> schemeSteps)
        {
            List<SchemeStepFlowModel> schemeStepFlowModels = new List<SchemeStepFlowModel>();

            foreach (var elt in schemeSteps)
            {
                schemeStepFlowModels.Add(new SchemeStepFlowModel()
                {
                    Activity = elt.Activity,
                    Occurence = elt.Occurence,
                    Ordre = elt.Ordre,
                    Gestionnaire = controleurs.FirstOrDefault(c => c.DetailsControleurs == elt.Gestionnaire && c.Description == elt.Service).Controller,
                    Service = controleurs.FirstOrDefault(c => c.DetailsControleurs == elt.Gestionnaire && c.Description == elt.Service).Action,
                    Description = controleurs.FirstOrDefault(c => c.DetailsControleurs == elt.Gestionnaire && c.Description == elt.Service).Description,
                    DetailsControleurs = controleurs.FirstOrDefault(c => c.DetailsControleurs == elt.Gestionnaire && c.Description == elt.Service).DetailsControleurs
                });
            }
            return schemeStepFlowModels;
        }
    }
}
