using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LOC_WebApi.Models
{
    public class AuthModel
    {
        LoginModel Login { get; set; }
        RegisterModel Registration { get; set; }

    }
}