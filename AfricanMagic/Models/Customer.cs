﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace AfricanMagic.Models
{
    public class Customer
    {
        [Required(ErrorMessage = "Cannot be blank.")]
        [StringLength(16, MinimumLength = 3, ErrorMessage = "Minimum Length has to be 3 letters.")]
        [DataType(DataType.Text)]
        [Display(Name = "Customer First Name")]
        public string CustomerFName { get; set; }

        [Required(ErrorMessage = "Cannot be blank.")]
        [StringLength(16, MinimumLength = 3, ErrorMessage = "Minimum Length has to be 3 letters.")]
        [DataType(DataType.Text)]
        [Display(Name = "Customer Last Name")]
        public string CustomerLName { get; set; }

        //ID will be automatically generated.(Not customer's Actual ID number)
        [Key]
        [Required]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public string CustomerID { get; set; }

        [Required(ErrorMessage = "Cannot be blank.")]
        [Display(Name = "Customer Email")]
        [DataType(DataType.Text)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Cannot be blank.")]
        [Display(Name = "Shipping Address")]
        [DataType(DataType.Text)]
        public string ShippingAddress { get; set; }

        [Required(ErrorMessage = "Cannot be blank")]
        [Display(Name = "Customer Phone Number")]
        [StringLength(10, ErrorMessage = "Invalid Number. Start with '0'. ")]
        [DataType(DataType.Text)]
        public string PhoneNumber { get; set; }

        public virtual ICollection<Sales> Sale { get; set; }

        public string GenerateID()
        {
            string x = CustomerFName.Substring(0, 2) + CustomerLName.Substring(0, 2) + CustomerID;

            return x;

        }
    }
}