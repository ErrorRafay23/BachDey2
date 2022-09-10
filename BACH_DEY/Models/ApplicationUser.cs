using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BACH_DEY.Models
{
    public class ApplicationUser : IdentityUser
    {
        
        public string name { get; set; }
         public string city { get; set; }
       
    }
}
