using SQLite;

namespace Videothek.Persistence.Entities
{
    [Table("Videos")]
    public sealed class VideoEntity 
    {
        [PrimaryKey,AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public string CoverImageLocation { get; set; }
        public int Availability { get; set; }
    }
}
