using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetSwag.Models
{
    public class OrderDetails
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }

        public string Gender { get; set; }

        public string TShirtSize { get; set; }

        public DateTime DateOfOrder { get; set; }

        public string TShirtColour { get; set; }


        public string ShipAddress { get; set; }



    }
}
