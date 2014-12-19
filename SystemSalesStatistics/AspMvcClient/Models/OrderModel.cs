using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AspMvcClient.Models
{
    public class OrderModel
    {
        public int? Id { get; set; }

        [Display(Name = " Date")]
        [Required]
        public System.DateTime OrderDate { get; set; }

        [Display(Name = " Product")]
        [Required]
        public string ProductName { get; set; }

        [Display(Name = "Cost")]
        [Required]
        public double Cost { get; set; }

        [Display(Name = " Client")]
        [Required]
        public string ClientName { get; set; }
       
        [Display(Name = "Manager")]
        [Required]
        public string ManagerName { get; set; }
    }
}