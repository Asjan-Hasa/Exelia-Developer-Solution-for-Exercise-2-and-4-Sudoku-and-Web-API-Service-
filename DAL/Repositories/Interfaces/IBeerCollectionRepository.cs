using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Interfaces
{
    public interface IBeerCollectionRepository
    {
        BeerModel? SearchBeer(string value);
        List<BeerModel> GetBeerCollection();
        ResultModel AddEditBeer(BeerModel beer);
        ResultModel RateBeer(decimal rate,long? beerId);
    }
}
