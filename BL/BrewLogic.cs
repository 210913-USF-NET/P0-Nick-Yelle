using Models;
using DL;
using System.Collections.Generic;

namespace BL
{
    public class BrewLogic : IBrewLogic, IBreweryLogic
    {
        private IRepo _IRepo;

        public BrewLogic(IRepo repo)
        {
            _IRepo = repo;
        }
        public void AddBrew(Brew brew)
        {
            _IRepo.AddBrew(brew);
        }

        // public void AddBrewery(Brewery brewery)
        // {
        //     _IRepo.AddBrewery();
        // }

        // public List<Brewery> GetAllBreweries()
        // {
        //     throw new System.NotImplementedException();
        }

        public List<Brew> GetAllBrews()
        {
            return _IRepo.GetAllBrews();
        }
    }
}