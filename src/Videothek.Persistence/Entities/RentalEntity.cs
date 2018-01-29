using System;
using SQLite;

namespace Videothek.Persistence.Entities
{
    [Table("Rentals")]
    public sealed class RentalEntity
    {
        [PrimaryKey,AutoIncrement]
        public int ID { get; set; }
        [Indexed]
        public int VideoID { get; set; }
        public DateTime Date { get; set; }
        [Indexed]
        public int UserID { get; set; }
    }
}
