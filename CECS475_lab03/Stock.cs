using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CECS475_lab03
{
   class Stock
   {
      public string Name { get; private set; }

      public int InitialValue { get; private set; }

      public int MaxChange { get; private set; }

      public int Notification { get; private set; }

      public Stock( string name, int value, int change, int notify )
      {
         Name = name;
         InitialValue = value;
         MaxChange = change;
         Notification = notify;
      }

      public void ChangeStockValue()
      {
         // code
      }

      public void Activate()
      {
         // code
      }
   }
}
