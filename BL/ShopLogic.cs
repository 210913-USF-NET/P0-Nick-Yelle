using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;
using DL;

namespace BL
{
    public class ShopLogic : ISBL
    {
        //Properties.
        private ISRepo _repo;

        //Constructor.
        public ShopLogic(ISRepo repo)
        {
            _repo = repo;
        }

        public List<Brewery> GetBreweries()
        {
            return _repo.GetBreweries();
        }

        public List<Brew> GetBrews()
        {
            return _repo.GetBrews();
        }
    }
}