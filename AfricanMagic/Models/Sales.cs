﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace AfricanMagic.Models
{
    public class Sales
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SalesID { get; set; }

        [Display(Name = "Customers")]
        public string CustomerID { get; set; }

        [Display(Name = "Items Sold")]
        public int ItemID { get; set; }

        [Display(Name = "Total amount paid")]
        [DataType(DataType.Currency)]
        public double FinalAmount { get; set; }

        [Display(Name = "Date Of Purchase")]
        [DataType(DataType.DateTime)]
        public DateTime DateOfPurchase { get; set; }

        
        [ForeignKey("CustomerID")]
        public virtual Customer Customers { get; set; }
        [ForeignKey("ItemID")]
        public virtual Inventory Inventory { get; set; }
    }
}