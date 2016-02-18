/******************************************
    George Rhee and Imanuel Kurniawan
    CECS 475 - Section 03
    Lab Assignment #3 - Stock Application
    Due February 16, 2016
    Stock.cs
******************************************/

//--------------IMPORT LIBRARIES--------------
using System;
using System.Threading;

namespace CECS475_lab03
{
    class Stock
    {
        //This variable stores the name of the stock
        public string name { get; set; }

        //This variable stores the initial value of the stock
        public double initialValue { get; set; }

        //This variable stores the current value of the stock
        public double currentValue { get; set; }

        //This variable is used to set the limit of each change
        public int maxChange { get; set; }

        //This variable records the total number of changes made
        public int numOfChange { get; set; }

        //This variable is used as the treshold of the stock price
        public double priceTreshold { get; set; }

        //Create a new thread to handle the process
        private Thread thread;

        //Create a new random object
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

        //This method is used to raise the event
        protected virtual void OnStockEvent(EventData e)
        {
            EventHandler<EventData> handler = StockEvent;
            if (handler != null)
            {
                handler(this, e);
            }
        } // end method OnStockEvent

        //This method is used to change the value of the stock
        public void ChangeStockValue()
        {
            // Random integer between 1 - maxChange
            currentValue += myRand.Next(1, (maxChange + 1));
            //Increase the number of change by 1
            numOfChange++;
            //Check whether the treshold is reached
            if ((currentValue - initialValue) > priceTreshold)
            {
                //Raise the event
                EventData temp = new EventData();
                temp.stockName = name;
                temp.currentValue = currentValue;
                temp.numOfChange = numOfChange;
                OnStockEvent(temp);
            }
        } // end method ChangeStockValue

        // Threading
        //This method will be called upon thread creation
        public void Activate()
        {
            //Change the stock's value 30 times
            for (int counter = 0; counter < 30; counter++)
            {
                //Put the thread to sleep for 500 ms
                Thread.Sleep(500);
                //Change the stock value
                ChangeStockValue();
            }
        } // end method Activate
    } // end class Stock
}//end namespace CECS475_lab03