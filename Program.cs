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
            /// <summary>
            /// данные для теста
            /// </summary>
            //string nameSearchingPolygon = "москва";
            //int countPointPolygon = 10;
            //string nameFile = "jsonDowloading.txt";
            if (СheckingInputData.СheckSourceData(args))
            {
                string nameSearchingPolygon = args[0].ToLower();
                int countPointPolygon = Int32.Parse(args[1]);
                string nameFile = args[2];

                LoadingJsonNominatimOpenstreetmap lj = new LoadingJsonNominatimOpenstreetmap(nameSearchingPolygon, nameFile);
                await lj.CreateFileDataJson();

                /// <summary>
                /// вывод в консоль только определенного количества точек
                /// </summary>
                var inputStream = File.ReadAllText(nameFile);
                var jsonDataCollection = JsonConvert.DeserializeObject<List<Polygon>>(inputStream);
                foreach (var jsonData in jsonDataCollection)
                {
                    Console.WriteLine(jsonData.DisplayName);
                    int counter = 0;
                    foreach (var obj in jsonData.Geojson.Coordinates)
                    {
                        if ((counter % countPointPolygon) == 0)
                        {
                            Console.Write(", ", obj);
                        }
                        counter++;
                    }
                }
                Console.WriteLine("Запрос выполнен");
            }
            
            else
            {
                Console.WriteLine("Try entering the data again");
            }
           
        }
    }
}
