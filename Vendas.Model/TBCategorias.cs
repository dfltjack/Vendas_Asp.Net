﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Vendas.Model
{
    public partial class TBCategorias
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [StringLength(20)]
        [Unicode(false)]
        [Display(Name = "Descrição")]
        public string Descrição { get; set; }
    }
}