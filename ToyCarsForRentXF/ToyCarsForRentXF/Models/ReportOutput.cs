using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyCarsForRentXF.Models
{
    public class ReportOutput
    {
        private string carTitle;
        public string CarTitle
        {
            get { return carTitle; }
            set { carTitle = value; }
        }

        private string rentDate;
        public string RentDate
        {
            get { return rentDate; }
            set { rentDate = value; }
        }

        private string minutes;
        public string Minutes
        {
            get { return minutes; }
            set { minutes = value; }
        }

        private string price;
        public string Price
        {
            get { return price; }
            set { price = value; }
        }

    }
}
