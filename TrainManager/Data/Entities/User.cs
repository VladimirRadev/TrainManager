using System.Collections.Generic;

namespace Data.Entities
{
    public class User : BaseEntity
    {
        public User()
        {
           
        }

        public string Username { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public bool IsAdmin { get; set; }
        public virtual Ticket Ticket { get; set; }
    }
}
