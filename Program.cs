using System;
using System.Net;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp.Geolocation
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // string nameFile = args[2];
            string nameFile = "jsonDowloading.txt";
            //string nameSearchingPolygon = args[0];
            string nameSearchingPolygon = "москва";
            // int countPointPolygon = int.Parse(args[1]);
            int countPointPolygon = 10;
            string adressUrlFromUser = $"https://nominatim.openstreetmap.org/search?q={nameSearchingPolygon}&format=json&polygon_geojson=1";
            Console.WriteLine(adressUrlFromUser);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(adressUrlFromUser);
            request.UseDefaultCredentials = true;
            request.UserAgent = "[any words that is more than 5 characters]";
            HttpWebResponse response = (HttpWebResponse)await request.GetResponseAsync();
            List<string> ListStrings = new List<string>();
            List<Polygon> polygons = new List<Polygon>();
            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    string line = "";
                    while ((line = reader.ReadLine()) != null)
                    {
                        ListStrings.Add(line);
                       
                    }

                    if (File.Exists(nameFile))
                    {
                        File.Delete(nameFile);
                    }
                    File.WriteAllLines(nameFile, ListStrings);
                }
            }
            var inputStream = File.ReadAllText(nameFile);
            var jsonDataCollection = JsonConvert.DeserializeObject<List<Polygon>>(inputStream);
            foreach (var jsonData in jsonDataCollection)
            {
                Console.WriteLine(jsonData.DisplayName);
                int counter = 0;
                foreach (var obj in jsonData.geojson.Coordinates)
                {
                    if ((counter % countPointPolygon) == 0)
                    {
                        Console.WriteLine(obj);
                    }
                    counter++;
                }
            }

            response.Close();
            Console.WriteLine("Запрос выполнен");
            Console.Read();

        }
    }
}
