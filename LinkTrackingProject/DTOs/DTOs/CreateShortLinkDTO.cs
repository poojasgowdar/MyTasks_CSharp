﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.DTOs
{
    public class CreateShortLinkDTO
    {
        public string OriginalUrl { get; set; }
        public string? CustomAlias { get; set; }
    }
}
