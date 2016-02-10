using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CECS475_lab03
{
   class StockBroker
   {
      public string Name { get; private set; }

      public List<Stock> StockList {get; set;}

      public StockBroker( string name )
      {
         Name = name;
         StockList = new List<Stock>();
      } 

      public void AddStock(Stock s)
      {
         StockList.Add(new Stock(s.Name, s.InitialValue, s.MaxChange, s.Notification) { });
      }
   }
}
