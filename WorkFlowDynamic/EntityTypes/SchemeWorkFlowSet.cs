﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorkFlowDynamic.DataEntityTypes
{
    public partial class SchemeWorkFlowSet
    {
        public SchemeWorkFlowSet()
        {
            Scheme_StepSet = new HashSet<Scheme_StepSet>();
        }

        [Key]
        public long Id { get; set; }
        [Required]
        [StringLength(50)]
        public string SchemeName { get; set; }
        public bool? state { get; set; }

        [InverseProperty("SchemeWorkFlow")]
        public virtual ICollection<Scheme_StepSet> Scheme_StepSet { get; set; }
    }
}