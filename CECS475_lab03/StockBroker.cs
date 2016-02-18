/******************************************
    George Rhee and Imanuel Kurniawan
    CECS 475 - Section 03
    Lab Assignment #3 - Stock Application
    Due February 16, 2016
    StockBroker.cs
******************************************/

//--------------IMPORT LIBRARIES--------------
using System;
using System.Collections.Generic;
using System.Threading;
using System.IO;

namespace CECS475_lab03
{
    class StockBroker
    {
        // Mutex lock for writing privileges
        private static Mutex mut = new Mutex();

        // The directory the text file is to be created
        //NOTE: The file can be found in ...\CECS475-Lab03\CECS475_lab03\bin\Debug
        string path = @".\EventLog.txt";

        //This variable is used to store the broker's name
        public string Name { get; private set; }

        //This variable is used to store the stocks that the broker handles
        public List<Stock> StockList { get; set; }

        // Constructor
        public StockBroker(string name)
        {
            Name = name;
            StockList = new List<Stock>();
        } // end constructor StockBroker

        //This method is used to add stock into the StockList
        public void AddStock(Stock s)
        {
            StockList.Add(s);
            s.StockEvent += MyEventHandler;
        } // end method AddStock

        //This method is used to handle the event when it's raised
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
                    //Write the table header to the file
                    sw.WriteLine("Broker".PadRight(15) + "Stock".PadRight(15) +
                                 "Value".PadRight(15) + "Changes".PadRight(15) +
                                 "\r\n");
                }
            }

            // This text is always added, making the file longer over time
            // if it is not deleted.
            using (StreamWriter sw = File.AppendText(path))
            {
                //Write the event data to the file
                sw.WriteLine(Name.PadRight(15) + e.stockName.PadRight(15) +
                              e.currentValue.ToString().PadRight(15) +
                              e.numOfChange.ToString());
            }
            // Release mutex
            mut.ReleaseMutex();
        } // end class MyEventHandler
    } // end class StockBroker
}//end namespace CECS475_lab03