using CsvHelper;
using System.Globalization;

namespace ConsoleApp12
{
    public class BuildFIles
    {
        public static void GenerateCSV(List<CSVExport> list)
        {
            using var writer = new StreamWriter(@"C:\bulk\file.csv");
            using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
            csv.WriteRecords(list);
        }

        public static void GenerateTXT(List<CSVExport> list)
        {
            using StreamWriter outputFile = new StreamWriter(@"C:\bulk\file.txt");
            outputFile.WriteLine($"AssetID,TypeID,OfferID,Valor");
            foreach (var line in list)
                outputFile.WriteLine($"{line.AssetID},{line.TypeID},{line.OfferID},{line.Valor.ToString().Replace(",", ".")}");
        }
    }
}
