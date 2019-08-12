using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace LOC_WebApi.Models
{
    public class ApplicationUser : IdentityUser
    {
        public int Year { get; set; }

        public int UserRating { get; set; }

        public ApplicationUser()
        {
            UserRating = 2000;
        }
    }
}