using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;

namespace Ticker_Information_INquiry
{
    class Program
    {
        static void Main(string[] args)
        {
            string username = "intrinio username";
            string password = "intrinio password";
            Console.WriteLine("Hello. This can provide you with four data points for the ticker of your choosing. Ask about Market Cap, CEO, closing prices, and Sectors");
            Console.WriteLine("When you are done using this application type exit to leave");
            var client = new WebClient { Credentials = new NetworkCredential(username, password) };
            var sector = client.DownloadString("https://api.intrinio.com/data_point?identifier=AAPL&item=sector");
            var marketcap = client.DownloadString("https://api.intrinio.com/data_point?identifier=AAPL&item=marketcap");
            var close_price = client.DownloadString("https://api.intrinio.com/data_point?identifier=AAPL&item=close_price");
            var ceo = client.DownloadString("https://api.intrinio.com/data_point?identifier=AAPL&item=ceo");
            JObject sectero = JObject.Parse(sector);
            JObject marketcapo = JObject.Parse(marketcap);
            JObject close_price0 = JObject.Parse(close_price);
            JObject ceoo = JObject.Parse(ceo);
            var secters = (string)sectero.SelectToken("value");
            string marketcaps = (string)marketcapo.SelectToken("value");
            string close_prices = (string)close_price0.SelectToken("value");
            string ceos = (string)ceoo.SelectToken("value");
            string line;
            while ((line = Console.ReadLine()) != "exit")
            {
                if (line.Contains("sector") || line.Contains("Sector") || line.Contains("SECTOR")) { Console.WriteLine(secters); }
                else if (line.Contains("market") || line.Contains("MARKET") || line.Contains("Market")) { Console.WriteLine(marketcaps); }
                else if (line.Contains("price") || line.Contains("Price") || line.Contains("PRICE")) { Console.WriteLine(close_prices); }
                else if (line.Contains("ceo") || line.Contains("CEO") || line.Contains("Ceo") || line.Contains("Boss")) { Console.WriteLine(ceos); }
                else { Console.WriteLine("You can only ask about CEO, Market Capitalization, Sector, and Closing Price"); }
            }
        }
    }
}
