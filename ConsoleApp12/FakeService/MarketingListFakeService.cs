using Bogus;

namespace ConsoleApp12.FakeService
{
    public class MarketingListFakeService
    {
        public static List<CSVExport> GerarMassa()
        {
            int index = 0;
            int totalList = 0;
            var csvList = new List<CSVExport>();

            while (totalList < 1_000_001)
            {
                string gsm = GerarGsm();
                while (index < 3)
                {                    
                    int typeID = index + 1;
                    int offerId = GerarOfferId();
                    decimal valor = (66.99m - index )* 0.8m;
                    ++index;
                    csvList.Add(new CSVExport
                    {
                        AssetID = gsm,
                        OfferID = offerId,
                        TypeID = typeID,
                        Valor = Math.Round(valor,2)
                    });
                    totalList++;
                }
                index = 0;
            }

            return csvList;
        }

        private static string GerarGsm()
        {
            Random rnd = new Random();
            string ddd = rnd.Next(1, 99).ToString("D2");
            string numero = rnd.Next(100000000,999999999).ToString("D2");
            string numeroFinal = string.Concat(ddd, numero);
            return numeroFinal.Replace(numeroFinal.Substring(2, 1), "9");
        }

        private static int GerarOfferId()
        {
            Random rnd = new Random();
            return rnd.Next(100, 900);
        }
    }
}
