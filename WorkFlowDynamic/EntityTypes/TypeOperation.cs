﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorkFlowDynamic.DataEntityTypes
{
    public partial class TypeOperation
    {
        [Key]
        public long Id { get; set; }
        [StringLength(50)]
        public string Label { get; set; }
        [StringLength(50)]
        public string Description { get; set; }
        public bool? Status { get; set; }
    }
}