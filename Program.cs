using System;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace ConsoleApp.Geolocation
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string nameSearchingPolygon = args[0].ToLower();
            int countPointPolygon = int.Parse(args[1]);
            string nameFile = args[2];

            /// <summary>
            /// данные для теста
            /// </summary>
            //string nameSearchingPolygon = "москва";
            //int countPointPolygon = 10;
            //string nameFile = "jsonDowloading.txt";


            LoadingJsonNominatimOpenstreetmap lj = new LoadingJsonNominatimOpenstreetmap(nameSearchingPolygon);
            await lj.CreateFileDataJson(nameFile);

            /// <summary>
            /// вывод в консоль только определенного количества точек
            /// </summary>
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
            Console.WriteLine("Запрос выполнен");
        }
    }
}
