using System;

namespace Videothek.Core
{
    public class Rental
    {
        public int ID { get; set; }
        public Video Video { get; set; }
        public DateTime Date { get; set; }
        public User User { get; set; }
    }
}
