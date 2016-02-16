using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CECS475_lab03
{
    public class EventData : EventArgs
    {
        public String stockName
        {
            get; set;
        }
        public double currentValue
        {
            get; set;
        }
        public int numOfChange { get; set; }
    }
}
