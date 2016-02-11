using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CECS475_lab03
{
   class StockBroker
   {
      public static string Name { get; private set; }

      public static List<Stock> StockList {get; set;}

      public StockBroker( string name )
      {
         Name = name;
         StockList = new List<Stock>();
      } 

      public void AddStock(Stock s)
      {
         StockList.Add(s);
            s.StockEvent += MyEventHandler;
      }

        static void MyEventHandler(Object sender, EventData e)
        {
            Console.WriteLine(Name.PadRight(10) + e.stockName.PadRight(10) + e.currentValue.ToString().PadRight(10) + e.numOfChange.ToString().PadRight(10));
            //Environment.Exit(0);
        }
   }
}
