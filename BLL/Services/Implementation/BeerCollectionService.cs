using BLL.Services.Interfaces;
using DAL.Repositories.Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Implementation
{
    public class BeerCollectionService : IBeerCollectionService
    {
        private readonly IBeerCollectionRepository _beerCollectionRepository;

        public BeerCollectionService(IBeerCollectionRepository beerCollectionRepository)
        {
            _beerCollectionRepository = beerCollectionRepository;
        }

        public ResultModel AddEditBeer(BeerModel beer)
        {
            return _beerCollectionRepository.AddEditBeer(beer);
        }

        public List<BeerModel> GetBeerCollection()
        {
            return _beerCollectionRepository.GetBeerCollection();
        }

        public ResultModel RateBeer(decimal rate, long? beerId)
        {
            return _beerCollectionRepository.RateBeer(rate, beerId);
        }

        public BeerModel? SearchBeer(string value)
        {
            return _beerCollectionRepository.SearchBeer(value);
        }
    }
}
