using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ResultModel
    {
        public string? Message { get; set; }
        public bool HasWarning { get; set; }
        public bool HasError { get; set; }
    }
}
