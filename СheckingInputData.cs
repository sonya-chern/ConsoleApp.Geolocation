using System;

namespace ConsoleApp.Geolocation
{
    public class СheckingInputData
    {
        public static bool СheckSourceData (string [] args)
        {
            string nameSearchingPolygon = null;
            int countPointPolygon = 0;
            string nameFile = null;

            try
            {
                nameSearchingPolygon = args[0].ToLower();
            }
            catch (Exception e)
            {
                Console.WriteLine("The location data was entered incorrectly");
                Console.WriteLine("Exception: " + e.Message);
            }
    
            bool success = Int32.TryParse(args[1], out countPointPolygon);
            if (!success)
            {
                Console.WriteLine("The number of points was entered incorrectly");
            }

            try
            {
                nameFile = args[2].ToLower();
            }
            catch (Exception e)
            {
                Console.WriteLine("The file name was entered incorrectly");
                Console.WriteLine("Exception: " + e.Message);
            }

            if (nameSearchingPolygon.Length != 0 && countPointPolygon != 0 && nameFile.Length != 0)
            {
                return true;
            }
                
            return false;
        }
    }
}
