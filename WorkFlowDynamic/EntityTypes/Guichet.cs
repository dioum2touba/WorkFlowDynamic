﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorkFlowDynamic.DataEntityTypes
{
    public partial class Guichet
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public string Label { get; set; }
        [Required]
        [StringLength(50)]
        public string Code { get; set; }
    }
}