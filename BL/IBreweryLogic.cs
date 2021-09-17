using Models;
using System.Collections.Generic;

namespace BL
{
    public interface IBreweryLogic
    {
        void AddBrewery(Brewery brewery);
        List<Brewery> GetAllBreweries();
    }
}