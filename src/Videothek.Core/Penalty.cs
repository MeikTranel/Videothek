using System;
using Videothek.Persistence;

namespace Videothek.Core
{
    public class Penalty : IEntity
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public string Note { get; set; }
        public float Value { get; set; }
        public DateTime Date { get; set; }
        public bool Paid { get; set; }
    }
}
