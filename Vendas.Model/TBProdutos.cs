﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Vendas.Model
{
    public partial class TBProdutos
    {
        [Key]
        public int Id { get; set; }
        public int IdCategoria { get; set; }
        [Required]
        [StringLength(50)]
        [Unicode(false)]
        public string Descrição { get; set; }
        [Required]
        [StringLength(10)]
        [Unicode(false)]
        public string Unidade { get; set; }
        [StringLength(20)]
        [Unicode(false)]
        public byte[] Foto { get; set; }
        [StringLength(20)]
        [Unicode(false)]
        
        public string MimeType { get; set; }
        public double Preco { get; set; }
    }
}