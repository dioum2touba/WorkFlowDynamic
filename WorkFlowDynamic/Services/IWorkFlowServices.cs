using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkFlowDynamic.Models;

namespace WorkFlowDynamic.Services
{
    interface IWorkFlowServices
    {
        public List<ControleurModels> CopyMasterData();
    }
}
