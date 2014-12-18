using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AspMvcClient.Models
{
    public class ManagerModel
    {
        public int Id { get; set; }

        [Display(Name = " Manager name")]
        [Required]
        public string Name { get; set; }
    }
}