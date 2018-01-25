using Videothek.Persistence;

namespace Videothek.Core
{
    public class Video : IEntity
    {   

        public int ID { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public string CoverImageLocation { get; set; }
        public int Availability { get; set; }
    }
}
