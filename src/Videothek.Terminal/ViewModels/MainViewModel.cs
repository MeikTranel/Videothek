using Videothek.MasterDetail;

namespace Videothek.Terminal.ViewModels
{
    public class MainViewModel : MasterViewModel
    {
        public MainViewModel()
        {
            RegisterSimpleDetailViewModel(
                new TestScreenViewModel(
                    "WOLOLOLOLOLOLOLO"
                ),
                fullName: "Age of Empires",
                shortName: "AOE"
            );
            RegisterSimpleDetailViewModel(
                new TestScreenViewModel(
                    "Videos,Videos,Videos ..."
                ),
                fullName: "Alle Videos",
                shortName: "Videos"
            );
        }
    }
}
