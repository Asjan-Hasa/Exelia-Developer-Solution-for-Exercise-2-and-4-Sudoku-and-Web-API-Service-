﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ErrorResponse
    {
        public string? Message { get; set; }
        public string? Details { get; set; }
        public string? ErrorLocation { get; set; }
    }
}
