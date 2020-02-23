﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorkFlowDynamic.DataEntityTypes
{
    public partial class User
    {
        [Key]
        public long Id { get; set; }
        [StringLength(200)]
        public string FirstName { get; set; }
        [StringLength(100)]
        public string LastName { get; set; }
        [StringLength(256)]
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        [StringLength(25)]
        public string PhoneNumber { get; set; }
        [Required]
        [StringLength(256)]
        public string UserName { get; set; }
    }
}