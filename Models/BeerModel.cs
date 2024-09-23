using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class BeerModel
    {
        [Required] 
        public long BeerId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public decimal AverageRate { get; set; }

        public BeerModel()
        {
            Name = string.Empty;
        }
    }
}
