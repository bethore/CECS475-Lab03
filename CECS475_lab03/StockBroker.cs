using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;

namespace CECS475_lab03
{
    class StockBroker
    {
        // Mutex lock for writing privileges
        private static Mutex mut = new Mutex();

        // The directory the text file is to be created
        string path = @"C:\CECS475_Lab03.txt";

        public string Name { get; private set; }

        public List<Stock> StockList { get; set; }

        // Constructor
        public StockBroker(string name)
        {
            Name = name;
            StockList = new List<Stock>();
        } // end constructor StockBroker


        public void AddStock(Stock s)
        {
            StockList.Add(s);
            s.StockEvent += MyEventHandler;
        } // end method AddStock

        void MyEventHandler(Object sender, EventData e)
        {
            // Wait until safe to run
            mut.WaitOne();
            // Write to console
            Console.WriteLine(Name.PadRight(15) + e.stockName.PadRight(15) +
                              e.currentValue.ToString().PadRight(15) +
                              e.numOfChange.ToString());
            // This text is added only once to the file.
            if (!File.Exists(path))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine("Broker         Stock          Value          Changes\r\n");
                }
            }

            // This text is always added, making the file longer over time
            // if it is not deleted.
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine(Name.PadRight(15) + e.stockName.PadRight(15) +
                              e.currentValue.ToString().PadRight(15) +
                              e.numOfChange.ToString());
            }
            // Release mutex
            mut.ReleaseMutex();
        } // end class MyEventHandler
    } // end class StockBroker
}