using System.Collections.Generic;
using Models;
using System.IO;
using System.Text.Json;
using Serilog;

namespace DL
{
    public class FileRepo : IRepo
    {
        private const string filePath = "../DL/Brews.json";

        private string jsonString;

        public void AddBrew(Brew brew)
        {
            Log.Debug("DL adding brew, {0}", brew.ToString());
            List<Brew> allBrews = GetAllBrews();

            allBrews.Add(brew);

            jsonString = JsonSerializer.Serialize(allBrews);

            File.WriteAllText(filePath, jsonString);
        }

        public List<Brew> GetAllBrews()
        {
            jsonString = File.ReadAllText(filePath);

            return JsonSerializer.Deserialize<List<Brew>>(jsonString);
        }
    }
}