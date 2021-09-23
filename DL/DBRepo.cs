using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;
using Entity = DL.Entities;

namespace DL
{
    public class DBRepo : ISRepo
    {
        //Fields.
        private Entity.P0DBContext _context;

        //Constructor.
        public DBRepo(Entity.P0DBContext context)
        {
            _context = context;
        }

        //Methods.
        public List<Brewery> GetBreweries()
        {
            return _context.Breweries.Select(
                Brewery => new Models.Brewery() {
                    Id = Brewery.BreweryId,
                    Name = Brewery.Name,
                    State = Brewery.State,
                    City = Brewery.City
                }
            ).ToList();
        }

        public List<Brew> GetBrews()
        {
            return _context.Brews.Select(
                Brew => new Models.Brew() {
                    Id = Brew.BrewId,
                    Name = Brew.Name,
                    Price = Brew.Price,
                    BrewQuantity = Brew.BrewQuantity
                }
            ).ToList();
        }
    }
}