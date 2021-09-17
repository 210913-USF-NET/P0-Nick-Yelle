using Models;
using System.Collections.Generic;

namespace DL
{
    //implementing sinleton design pattern.
    public sealed class RAMRepo : IRepo
    {
        List<Brew> AllBrews = new List<Brew>();
        public void AddBrew(Brew brew)
        {
            AllBrews.Add(brew);
        }

        public List<Brew> GetAllBrews()
        {
            return AllBrews;
        }
    }
}