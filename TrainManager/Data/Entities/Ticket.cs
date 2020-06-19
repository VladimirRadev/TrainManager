using System;
using System.ComponentModel;

namespace Data.Entities
{
    public class Ticket : BaseEntity
    {
        public Ticket()
        {
            
        }
        [DisplayName("Seat # ")]
        public int Seat { get; set; }
        public DateTime Date { get; set; }

        [DisplayName("Arrival Time :")]
        public string ArrivalTime { get; set; }
        public string TrainName  { get; set; }
        public virtual Train Train { get; set; }
        public virtual User User { get; set; }
    }
}