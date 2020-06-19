using System;
using System.ComponentModel;

namespace Data.Entities
{
    public class Line :BaseEntity
    {
        public Line()
        {

        }
        public virtual Train Train { get; set; }

        [DisplayName("Train")]
        public int TrainId { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string DepartureTime { get; set; }
        public string ArrivalTime { get; set; }
        public DateTime Date { get; set; }
    }
}