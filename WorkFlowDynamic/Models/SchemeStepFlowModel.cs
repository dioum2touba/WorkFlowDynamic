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
        [Display(Name = "Nom de l'activité")]
        public string Activity { get; set; }
        [Display(Name = "Ordre Exécution")]
        public string Ordre { get; set; }
        [Display(Name = "Nombre Occurence")]
        public int Occurence { get; set; }
        [Display(Name = "Gestionnaire de service")]
        public string Gestionnaire { get; set; }
        [Display(Name = "Service")]
        public string Service { get; set; }
        public string id { get; set; }
        public string Description { get; set; }
        public string DetailsControleurs { get; set; }
    }
}
