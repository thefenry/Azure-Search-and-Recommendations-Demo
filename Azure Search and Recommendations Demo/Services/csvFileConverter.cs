using System;
using System.Collections.Generic;
using Azure_Search_and_Recommendations_Demo.Interfaces;
using Azure_Search_and_Recommendations_Demo.Models;
using System.IO;

namespace Azure_Search_and_Recommendations_Demo.Services
{
    public class CsvFileConverter : ICsvFileConverter
    {
        public FileInfo ConvertModelToCsv(List<Car> carList)
        {
            string path = @"C:\test.csv";
            string csv = CreateCsvString(carList);

            WriteFile(path, csv);

            return new FileInfo(path);
        }

        private static string CreateCsvString(List<Car> carList)
        {
            string csv = string.Empty;

            foreach (Car car in carList)
            {
                string id = car.Id.ToString();
                string itemName = string.Format("{0} {1}", car.Make, car.Model);
                string category = car.Make;
                string features = car.Rating.ToString();

                csv += string.Format("{0},{1},{2},,{3}\n", id, itemName, category, features);
            }

            return csv;
        }

        private void WriteFile(string path, string csv)
        {
            // This text is added only once to the file.
            if (!File.Exists(path))
            {
                // Create a file to write to.
                //string createText = "Hello and Welcome" + Environment.NewLine;
                File.WriteAllText(path, csv);
            }

            // This text is always added, making the file longer over time
            // if it is not deleted.
            string appendText = "This is extra text" + Environment.NewLine;
            File.AppendAllText(path, csv);

            // Open the file to read from.
            //string readText = File.ReadAllText(path);
            //Console.WriteLine(readText);
        }
    }
}