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
        private string NameSearchingPolygon { get; set; }
        private string NameFile { get; set; }

        public LoadingJsonNominatimOpenstreetmap(string newNameSearchingPolygon, string nameFile)
        {
            NameSearchingPolygon = newNameSearchingPolygon;
            NameFile = nameFile;
        }
        public async Task CreateFileDataJson()
        {
            string adressUrlFromUser = $"https://nominatim.openstreetmap.org/search?q={NameSearchingPolygon}&format=json&polygon_geojson=1";
            Console.WriteLine(adressUrlFromUser);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(adressUrlFromUser);
            request.UseDefaultCredentials = true;
            request.UserAgent = "[any words that is more than 5 characters]";
            HttpWebResponse response = (HttpWebResponse)await request.GetResponseAsync();
            List<string> ListStrings = new List<string>();
            using (Stream stream = response.GetResponseStream())
            {
                using StreamReader reader = new StreamReader(stream);
                    string line = "";
                    while ((line = reader.ReadLine()) != null)
                    {
                        ListStrings.Add(line);
                    }

                    if (File.Exists(NameFile))
                    {
                        File.Delete(NameFile);
                    }
                    File.WriteAllLines(NameFile, ListStrings);
            }
            response.Close();
        }
    }
}
