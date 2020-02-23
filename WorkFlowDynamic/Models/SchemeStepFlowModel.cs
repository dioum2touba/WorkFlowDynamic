using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WorkFlowDynamic.DataEntityTypes;

namespace WorkFlowDynamic.Models
{
    public class SchemeStepFlowModel
    {
        public string Activity { get; set; }

        public string Ordre { get; set; }

        public int Occurence { get; set; }

        public string Gestionnaire { get; set; }

        public string Service { get; set; }

        public string id { get; set; }

        public string Description { get; set; }

        public string DetailsControleurs { get; set; }
    }
}
