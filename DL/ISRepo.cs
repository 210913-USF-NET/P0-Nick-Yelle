using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;

namespace DL
{
    public interface ISRepo
    {
        List<Brewery> GetBreweries();

        List<Brew> GetBrews();
    }
}