using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;

namespace BL
{
    /// <summary>
    /// Interface designed to interact with customers
    /// </summary>
    public interface ISBL
    {
        ///Gets all breweries listed in database "Breweries".
        List<Brewery> GetBreweries();

        List<Brew> GetBrews();

        void AddCustomer(Customer cust);

        Customer CheckCustomerExists(string name);
    }
}