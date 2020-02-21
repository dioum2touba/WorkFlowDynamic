using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WorkFlowDynamic.Models;
using WorkFlowDynamic.Services;

namespace WorkFlowDynamic
{
    public class WorkFlowServices: IWorkFlowServices
    {
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
    }
}
