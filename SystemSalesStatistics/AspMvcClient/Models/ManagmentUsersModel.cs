using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security;
using System.Web;

namespace AspMvcClient.Models
{
    public class ManagmentUsersModel 
    {
        
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "DateCreation")]
        public DateTime DateCreation { get; set; }

        [Display(Name = "LastActivitiTime")]
        public DateTime LastActivitiTime { get; set; }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}