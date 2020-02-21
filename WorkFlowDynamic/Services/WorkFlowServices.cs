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

        public void SaveSchemeInDatabase(SchemeWorkFlowSet schemeWorkFlow, List<StepFlowModel> listStep)
        {
            //var list = CheckIfStepFlowExists(listStep);
            foreach (var elt in listStep)
            {
                _context.Scheme_StepSet.Add(new Scheme_StepSet()
                {
                    StepWorkFlow = new StepWorkFlowSet()
                    {
                        Controller = elt.cible,
                        Action = elt.service
                    },
                    Numberstep = Convert.ToInt32(elt.ordre),
                    SchemeWorkFlowId = schemeWorkFlow.Id,
                    Activity = schemeWorkFlow.SchemeName,
                    Occurences = 1
                });
            }
            _context.SaveChanges();
        }

        public List<StepWorkFlowSet> CheckIfStepFlowExists(List<StepFlowModel> stepFlow)
        {
            var stepFlows = _context.StepWorkFlowSet.ToList();
            var stepFlowList = TransFormLists(stepFlow);
            var difList = stepFlowList.Except(stepFlows).ToList();//.Where(a => stepFlowList.Any(a1 => a1.Action != a.Controller && a1.Action != a.Action)).ToList();
            return difList;
        }

        public List<StepWorkFlowSet> TransFormLists(List<StepFlowModel> stepFlow)
        {
            List<StepWorkFlowSet> stepWorkFlows = new List<StepWorkFlowSet>();
            foreach(var elt in stepFlow)
            {
                stepWorkFlows.Add(new StepWorkFlowSet()
                {
                    Action = elt.service,
                    Controller = elt.cible
                });
            }
            return stepWorkFlows;
        }

        public List<SchemeStepFlowModel> GetSchemeStepFlowModel(SchemeWorkFlowSet scheme, List<ControleurModels> controleurs)
        {
            var stepScheme = _context.Scheme_StepSet.Where(s => s.SchemeWorkFlowId == scheme.Id).ToList();
            var steps = _context.StepWorkFlowSet.Where(s => stepScheme.Select(s => s.StepWorkFlowId).Contains(s.Id)).ToList();
            List<SchemeStepFlowModel> schemeStepFlowModels = new List<SchemeStepFlowModel>();

            foreach(var elt in steps)
            {
                schemeStepFlowModels.Add(new SchemeStepFlowModel()
                {
                    Activity = stepScheme.FirstOrDefault(s => s.StepWorkFlowId == elt.Id).Activity,
                    Occurence = stepScheme.FirstOrDefault(s => s.StepWorkFlowId == elt.Id).Occurences,
                    Ordre = stepScheme.FirstOrDefault(s => s.StepWorkFlowId == elt.Id).Numberstep,
                    Gestionnaire = controleurs.FirstOrDefault(c => c.Controller == elt.Controller && c.Action == elt.Action).DetailsControleurs,
                    Service = controleurs.FirstOrDefault(c => c.Controller == elt.Controller && c.Action == elt.Action).Description,
                    scheme_Step = stepScheme.FirstOrDefault(s => s.StepWorkFlowId == elt.Id)
                });
            }
            return schemeStepFlowModels;
        }
    }
}
