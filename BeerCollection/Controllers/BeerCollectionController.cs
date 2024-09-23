using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace BeerCollection.Controllers
{
    public class BeerCollectionController : BaseController
    {
        private readonly IBeerCollectionService _beerCollectionService;
        public BeerCollectionController(IBeerCollectionService beerCollectionService)
        {
            _beerCollectionService = beerCollectionService;
        }
        [HttpGet]
        public IActionResult GetBeerCollection()
        {
            var beerCollections = _beerCollectionService.GetBeerCollection();
            return Ok(beerCollections);
        }
        [HttpGet]
        public IActionResult SearchBeer([FromQuery]string value)
        {
            var beer = _beerCollectionService.SearchBeer(value);
            if (beer == null) 
            {
                return Ok(GetReturnMessage($"No results found for the given value = {value}", true, false));
            }
            return Ok(beer);
        }
        [HttpPost]
        public IActionResult AddEditBeer([FromBody] BeerModel beerModel)
        {
            var result = _beerCollectionService.AddEditBeer(beerModel);
            return Ok(result);
        }
        [HttpPost]
        public IActionResult RateBeer([FromQuery] decimal rate, [FromQuery] long beerId)
        {
            var result = _beerCollectionService.RateBeer(rate,beerId);
            return Ok(result);
        }
    }
}
