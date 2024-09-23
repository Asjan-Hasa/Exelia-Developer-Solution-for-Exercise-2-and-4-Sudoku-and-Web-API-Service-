using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappings.BeerMapping
{
    public static partial class Mapping
    {
        public static BeerModel CreateModelFromEntity(Entities.Beer beer)
        {
            return new BeerModel { AverageRate = beer.BeerRatings.Any() ? beer.BeerRatings.Average(a => a.Rate) : 0, BeerId = beer.BeerId, Name = beer.Name };
        }
    }
}
