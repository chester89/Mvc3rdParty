﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mvc3rdParty.Web.Models
{
    public class LoginModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime? Edited { get; set; }
    }
}