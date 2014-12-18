using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AspMvcClient.Models
{
    public class ClientModel
    {
        public int Id { get; set; }

        [Display(Name = " Client name")]
        [Required]
        public string Name { get; set; }
    }
}