using System;
using Videothek.Persistence;

namespace Videothek.Core
{
    public class Rental : IEntity
    {
        public int VideoID { get; set; }
        public DateTime Date { get; set; }
        public int UserID { get; set; }
        public int ID { get; set; }
    }
}
