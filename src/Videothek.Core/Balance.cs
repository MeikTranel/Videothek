using Videothek.Persistence;

namespace Videothek.Core
{
    public class Balance: IEntity
    {
        
        public string Name { get; set; }
        public string IBAN { get; set; }
        private float _betrag;

        public float Betrag
        {
            get { return _betrag; }
            set { _betrag = value; }
        }


        public int ID => 1 ; // Es soll von dem Aktuellen benutzer 
     }   
}
