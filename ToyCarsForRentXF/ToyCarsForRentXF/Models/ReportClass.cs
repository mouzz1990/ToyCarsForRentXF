using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyCarsForRentXF.Models
{
    [Table("Reports")]
    public class ReportClass
    {
        private int reportId;
        [PrimaryKey, AutoIncrement, Column("id")]
        public int ReportId
        {
            get { return reportId; }
            set { reportId = value; }
        }

        private int toyCarId;
        [Column("ToyCarId")]
        public int ToyCarId
        {
            get { return toyCarId; }
            set { toyCarId = value; }
        }

        private int minutesCount;
        [Column("MinutesCount")]
        public int MinutesCount
        {
            get { return minutesCount; }
            set { minutesCount = value; }
        }

        private double price;
        [Column("Price")]
        public double Price
        {
            get { return price; }
            set { price = value; }
        }

        private DateTime rentDateTime;
        [Column("RentDateTime")]
        public DateTime RentDateTime
        {
            get { return rentDateTime; }
            set { rentDateTime = value; }
        }
    }
}
