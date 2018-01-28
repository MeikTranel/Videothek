using SQLite;

namespace Videothek.Persistence.Entities
{
    [Table("Users")]
    public sealed class UserEntity
    {
        [PrimaryKey,AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
