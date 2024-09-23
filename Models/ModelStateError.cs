using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ModelStateError
    {
        public List<string> Errors { get; set; }

        public ModelStateError()
        {
            Errors = new List<string>();
        }
    }
}
