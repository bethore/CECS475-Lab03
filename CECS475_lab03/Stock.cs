using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace CECS475_lab03
{
    class Stock
    {
        public string name { get; set; }

        public double initialValue { get; set; }

        public double currentValue { get; set; }

        public int maxChange { get; set; }

        public int numOfChange { get; set; }

        public double priceTreshold { get; set; }

        private Thread thread;

        Random myRand = new Random();

        //Event Declaration
        public event EventHandler<EventData> StockEvent;

        //Constructor
        public Stock(string name, double value, int change, double priceTreshold)
        {
            this.name = name;
            this.initialValue = value;
            this.currentValue = this.initialValue;
            this.maxChange = change;
            this.numOfChange = 0;
            this.priceTreshold = priceTreshold;
            thread = new Thread(new ThreadStart(Activate));
            thread.Start();
        } // end constructor Stock

        protected virtual void OnStockEvent(EventData e)
        {
            EventHandler<EventData> handler = StockEvent;
            if (handler != null)
            {
                handler(this, e);
            }
        } // end method OnStockEvent

        public void ChangeStockValue()
        {
            // Random integer between 1 - maxChange
            currentValue += myRand.Next(1, (maxChange + 1));
            numOfChange++;
            if ((currentValue - initialValue) > priceTreshold)
            {
                EventData temp = new EventData();
                temp.stockName = name;
                temp.currentValue = currentValue;
                temp.numOfChange = numOfChange;
                OnStockEvent(temp);
            }
        } // end method ChangeStockValue

        // Threading
        public void Activate()
        {
            for (int i = 0; i < 30; i++)
            {
                //Put the thread to sleep for 500 ms
                Thread.Sleep(500);
                //Change the stock value
                ChangeStockValue();
            }
        } // end method Activate
    } // end class Stock
}