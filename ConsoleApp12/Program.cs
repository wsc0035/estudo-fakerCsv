using Bogus;
using ConsoleApp12;
using CsvHelper;
using System.Globalization;

string FormatNumber(string number)
{
    Random random = new Random();
    var numberRandom = random.Next(10);
    return string.Concat(number.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", ""), numberRandom.ToString());
}

//var pessoa = new Faker<Pessoa>("pt_BR")
//                .RuleFor(c => c.Nome, f => f.Name.FullName())
//                .RuleFor(c => c.DataNascimento, f => f.Date.Between(DateTime.Now.AddYears(-20), DateTime.Now.AddYears(-40)))
//                .RuleFor(c => c.Telefone, f => FormatNumber(f.Phone.PhoneNumberFormat()))
//                .Generate(5);


var csvList = new Faker<CSVExport>("pt_BR")
              .RuleFor(c => c.AssetID, f => FormatNumber(f.Phone.PhoneNumberFormat()))
              .RuleFor(c => c.TypeID, f => f.Random.Int(1, 4))
              .RuleFor(c => c.OfferID, f => f.Random.Int(100, 800))
              .RuleFor(c => c.Valor, f => Math.Round(f.Random.Decimal(0.25m, 99.99m), 2))
              .Generate(3_000_000);

using (var writer = new StreamWriter(@"C:\bulk\file.csv"))
using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
{
    csv.WriteRecords(csvList); 
}

Console.ReadLine();
