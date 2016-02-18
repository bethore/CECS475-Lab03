/******************************************
    George Rhee and Imanuel Kurniawan
    CECS 475 - Section 03
    Lab Assignment #3 - Stock Application
    Due February 16, 2016
    EventData.cs
******************************************/

//--------------IMPORT LIBRARIES--------------
using System;

namespace CECS475_lab03
{
    //This class is used to store the event data when the event is raised
    public class EventData : EventArgs
    {
        //This variable is used to store the stock's name
        public String stockName {get; set;}
        //This variable is used to store the current value of the stock
        public double currentValue {get; set;}
        //This variable is used to store the total number of changes
        //when the event is raised
        public int numOfChange {get; set;}
    }//end class EventData
}//End namespace CECS475_lab03
