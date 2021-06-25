using System;
using System.Net;
using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConsoleApp.Geolocation
{
    /// <summary>
    /// класс получает данные JSON с сайта nominatim.openstreetmap.org  и сохраняет их в файл с именем, указанным пользователем
    /// </summary>
    public class LoadingJsonNominatimOpenstreetmap
    {
        private string _NameSearchingPolygon { get; set; }

        public LoadingJsonNominatimOpenstreetmap(string newNameSearchingPolygon)
        {
            _NameSearchingPolygon = newNameSearchingPolygon;
        }
        public async Task CreateFileDataJson(string nameFile)
        {
            string adressUrlFromUser = $"https://nominatim.openstreetmap.org/search?q={_NameSearchingPolygon}&format=json&polygon_geojson=1";
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
            response.Close();
        }
    }
}
