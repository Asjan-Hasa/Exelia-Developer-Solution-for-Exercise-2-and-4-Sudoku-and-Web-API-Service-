using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Interfaces
{
    public interface IBeerCollectionService
    {
        BeerModel? SearchBeer(string value);
        List<BeerModel> GetBeerCollection();
        ResultModel AddEditBeer(BeerModel beer);
        ResultModel RateBeer(decimal rate, long? beerId);
    }
}
