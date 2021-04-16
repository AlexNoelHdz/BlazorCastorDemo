using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorCastorDemoTripwire.Models
{
    public class SquareModel
    {
        public int Id { get; set; }//Unique identifier for each square
        public string Style { get; set; }//Style for each square, usefull to show/occult the square
        private bool isShown;
        public bool IsShown//Is Showing castor?
        {
            get => isShown;
            set
            {
                isShown = value;
                if (isShown)
                {
                    Style = "castor";
                    Console.WriteLine($"Se cambió a castor {Id}");
                }
                else
                {
                    Style = "";
                }
            }
        }
    }
}
