using DAL.BaseRepository;
using DAL.Entities;
using DAL.Mappings.BeerMapping;
using DAL.Repositories.Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Implementation
{
    public class BeerCollectionRepository(BeerCollectionContext beerCollectionContext) : RepositoryBase<Beer>(beerCollectionContext), IBeerCollectionRepository
    {
        public ResultModel AddEditBeer(BeerModel beer)
        {
            try
            {
                ResultModel result;
                if (beer.BeerId != 0) // Update beer
                {
                    var beerDb = GetById(beer.BeerId);
                    if (beerDb != null)
                    {
                        beerDb.Name = beer.Name;
                        UpdateEntity(beerDb);
                        result = GetReturnMessage("Beer updated successfully!", false, false);
                    }
                    else
                        result = GetReturnMessage("Beer not found", true, false);
                }
                else // Add Beer
                {
                    Insert(new Beer { Name = beer.Name });
                    result = GetReturnMessage("Beer added successfully!", false, false);
                }
                return result;
            }
            catch (Exception ex)
            {
                return GetReturnMessage($"Exception happened with message : {ex.Message}", false, true);
            }

        }

        public List<BeerModel> GetBeerCollection()
        {
            try
            {
                return GetAll().Select(b => Mapping.CreateModelFromEntity(b)).ToList();

            }
            catch (Exception)
            {
                throw;
            }
        }

        public ResultModel RateBeer(decimal rate, long? beerId)
        {
            try
            {
                if (rate < 0 || rate > 5)
                    return GetReturnMessage("Rate should be a positive value from 1 to 5", true, false);
                else
                {
                    var beer = GetById(beerId);
                    if (beer != null)
                    {
                        BeerRating beerRating = new BeerRating
                        {
                            BeerId = beerId,
                            Rate = rate
                        };
                        _applicationDbContext.BeerRatings.Add(beerRating);
                        _applicationDbContext.SaveChanges();
                        return GetReturnMessage("Rated successfully!", false, false);
                    }
                    else
                        return GetReturnMessage($"Beer with given id = {beerId} was not found!", true, false);

                }
            }
            catch (Exception ex)
            {
                return GetReturnMessage($"Exception happened with message : {ex.Message}", false, true);
            }

        }

        public BeerModel? SearchBeer(string value)
        {
            try
            {
                return this.SearchFor(b => b.Name.Contains(value)).Select(s => Mapping.CreateModelFromEntity(s)).FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
