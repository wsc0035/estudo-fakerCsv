using Bogus;

namespace ConsoleApp12.FakeService
{
    public class MarketingListFakeService
    {
        public static List<CSVExport> GerarMassa()
        {
            int index = 0;
            int totalList = 0;
            decimal discount = 1m;
            decimal discountAcc = 0.1m;
            var csvList = new List<CSVExport>();

            while (totalList < 3_000_000)
            {
                string gsm = GerarGsmValid();
                while (index < 3)
                {
                    discountAcc = discountAcc + 0.1m;
                    int typeID = index + 1;
                    int offerId = GerarOfferId();
                    decimal valor = 66.99m * (discount - discountAcc);
                    ++index;
                    csvList.Add(new CSVExport
                    {
                        AssetID = gsm,
                        OfferID = offerId,
                        TypeID = typeID,
                        Valor = Math.Round(valor, 2)
                    });
                    totalList++;
                }
                index = 0;
                discountAcc = 0.1m;
            }

            return csvList;
        }

        private static string GerarGsm()
        {
            Random rnd = new Random();
            string ddd = rnd.Next(1, 99).ToString("D2");
            string numero = rnd.Next(900000000, 999999999).ToString("D2");           
            return string.Concat(ddd, numero);
        }

        private static string GerarGsmValid()
        {
            Random rnd = new Random();
            int dddIndex = rnd.Next(1, 67);
            string numero = rnd.Next(900000000, 999999999).ToString("D2");  
            return string.Concat(ValidDDD(dddIndex), numero);
        }

        private static int GerarOfferId()
        {
            Random rnd = new Random();
            return rnd.Next(100, 900);
        }

        private static string ValidDDD(int index)
        {
            string[] dddArray = {   "11",
                                    "12",
                                    "13",
                                    "14",
                                    "15",
                                    "16",
                                    "17",
                                    "18",
                                    "19",
                                    "21",
                                    "22",
                                    "24",
                                    "27",
                                    "28",
                                    "31",
                                    "32",
                                    "33",
                                    "34",
                                    "35",
                                    "37",
                                    "38",
                                    "41",
                                    "42",
                                    "43",
                                    "44",
                                    "45",
                                    "46",
                                    "47",
                                    "48",
                                    "49",
                                    "51",
                                    "53",
                                    "54",
                                    "55",
                                    "61",
                                    "62",
                                    "63",
                                    "64",
                                    "65",
                                    "66",
                                    "67",
                                    "68",
                                    "69",
                                    "71",
                                    "73",
                                    "74",
                                    "75",
                                    "77",
                                    "79",
                                    "81",
                                    "82",
                                    "83",
                                    "84",
                                    "85",
                                    "86",
                                    "87",
                                    "88",
                                    "89",
                                    "91",
                                    "92",
                                    "93",
                                    "94",
                                    "95",
                                    "96",
                                    "97",
                                    "98",
                                    "99" };
            return dddArray[index];
        }
    }
}
