﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Helpers.Helper
{
    public class BasicAuthenticationClient:IIdentity
    {
        public string? AuthenticationType { get; set; }
        public bool IsAuthenticated { get; set; }
        public string? Name { get; set; }

    }
}
