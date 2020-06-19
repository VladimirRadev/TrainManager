using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Entities
{
    public class Train : BaseEntity
    {
        public Train()
        {
            this.Passengers = new HashSet<User>();
            this.Lines = new HashSet<Line>();
        }
        [Required]
        public string Name { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than {0}")]
        public int Capacity { get; set; }
        [Required]
        public bool Fast { get; set; }
        public virtual Line Line { get; set; }
        public int LineId { get; set; }
        public virtual ICollection<User> Passengers { get; set; }

        public virtual ICollection<Line> Lines { get; set; }

    }
}
