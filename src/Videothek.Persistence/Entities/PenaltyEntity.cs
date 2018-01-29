using System;
using SQLite;

namespace Videothek.Persistence.Entities
{
    [Table("Penalties")]
    public sealed class PenaltyEntity
    {
        [PrimaryKey,AutoIncrement]
        public int ID { get; set; }
        [Indexed]
        public int UserID { get; set; }
        public string Note { get; set; }
        public float Value { get; set; }
        public DateTime Date { get; set; }
        public bool Paid { get; set; }
    }
}
