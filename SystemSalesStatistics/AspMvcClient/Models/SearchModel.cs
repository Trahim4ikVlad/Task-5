using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AspMvcClient.Models
{
    public class SearchModel
    {
        [Display(Name = " Client")]
        public  string ClientName { get; set; }

         [Display(Name = "Manager")]
        public string ManagerName { get; set; }

         [Display(Name = " Date")]
         [DataType(DataType.Date)]
         [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime OrderDate { get; set; }

         [Display(Name = "Product")]
        public string ProductName { get; set; }
    }
}