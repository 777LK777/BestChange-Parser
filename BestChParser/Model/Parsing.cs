using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ParseLib.MODEL.Work;
using ParseLib;
using ParseLib.Model;

namespace BestChParser.Model
{
    static public class Parsing
    {
        private static List<IParserSettings> addresses = new List<IParserSettings>
        {
            new SiteSettings("https://www.bestchange.ru/qiwi-to-bitcoin-cash.html"),
            new SiteSettings("https://www.bestchange.ru/qiwi-to-bitcoin.html"),
            new SiteSettings("https://www.bestchange.ru/qiwi-to-ethereum.html"),
            new SiteSettings("https://www.bestchange.ru/qiwi-to-ripple.html"),
            new SiteSettings("https://www.bestchange.ru/qiwi-to-dogecoin.html")
        };

        static List<BaseExchanger> exchangers;
        
        static public IEnumerable<BaseExchanger> Run()
        {
            ParserWorker<BaseExchanger[]> worker = new ParserWorker<BaseExchanger[]>(new SiteParser(), addresses);
            worker.OnNewData += Parse_OnNewData;
            worker.OnCompleted += Parse_OnCompleted;
            worker.Start();
            return exchangers;
        }        

        static private void Parse_OnCompleted(object obj)
        {
            Console.WriteLine("Распарсили");
        }

        static public void Parse_OnNewData(object arg1, BaseExchanger[] arg2)
        {
            exchangers = new List<BaseExchanger>();
            exchangers.AddRange(arg2);
        }

        static public void AddAddress(string address)
        {
            addresses.Add(new SiteSettings(address));
        }
    }
}
