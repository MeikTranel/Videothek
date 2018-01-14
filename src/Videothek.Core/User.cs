namespace Videothek.Core
{
    public class User
    {
        public User(int id, string name)
        {
            ID = id;
            Name = name;
        }

        public int ID { get; }
        public string Name { get; }
    }
}
