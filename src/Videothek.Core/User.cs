using Videothek.Persistence;

namespace Videothek.Core
{
    public class User : IEntity
    {
        public User(int id, string name)
        {
            ID = id;
            Name = name;
            Balance = 0;
        }

        public int ID { get; }
        public string Name { get; }
        public float Balance { get; set; }
    }
}
