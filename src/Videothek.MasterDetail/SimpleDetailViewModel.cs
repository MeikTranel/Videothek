using System;
using Stylet;

namespace Videothek.MasterDetail
{
    public class SimpleDetailViewModel : Screen,IDetailViewModel
    {
        public IScreen Screen { get; private set; }
        public string FullName { get; private set; }
        public string ShortName { get; private set; }

        public SimpleDetailViewModel(IScreen screen, string fullName,string shortName)
        {
            Screen = screen ?? throw new ArgumentNullException(nameof(Screen));
            FullName = fullName;
            ShortName = shortName;
        }
    }
}
