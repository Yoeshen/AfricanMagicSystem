using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace AfricanMagic.Models
{
    public class Inventory
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ItemID { get; set; }

        [Required(ErrorMessage = "Required field.")]
        [DataType(DataType.Text)]
        [Display(Name = "Item Name")]
        public string ItemName { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Item Description")]
        public string ItemDescription { get; set; }

        [Required(ErrorMessage = "Required field.")]
        [DataType(DataType.Text)]
        [Display(Name = "Category")]
        public string Category { get; set; }

        [Required(ErrorMessage = "Required field.")]
        [DataType(DataType.Text)]
        [Display(Name = "Primary Colour")]
        public string Colour { get; set; }

        [Required(ErrorMessage = "Required field.")]
        [DataType(DataType.Text)]
        [Display(Name = "Size")]
        public string Size { get; set; }

        [Required(ErrorMessage = "Required field.")]
        [Display(Name = "Price(Rands)")]
        public double ItemPrice { get; set; }

        [Required]
        public byte ItemImage { get; set; }

        public virtual ICollection<Sales> sale { get; set; }
    }
}