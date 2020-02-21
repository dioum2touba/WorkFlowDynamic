using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkFlowDynamic.Models
{
    public class StepFlowModel
    {
        public string id { get; set; }

        public string cible { get; set; }

        public string service { get; set; }

        public string activity { get; set; }
    }
}
