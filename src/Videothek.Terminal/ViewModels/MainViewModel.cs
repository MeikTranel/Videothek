using Stylet;
using Videothek.Terminal.MasterDetail;

namespace Videothek.Terminal.ViewModels
{
    public class MainViewModel : MasterViewModel<IScreen>
    {
        public MainViewModel()
        {
            WrapAndRegisterViewModelAsDetailViewModel(
                new TestScreenViewModel(
                    "AOE",
                    "WOLOLOLOLOLOLOLO"
                )
            );
            WrapAndRegisterViewModelAsDetailViewModel(
                new TestScreenViewModel(
                    "Videos",
                    "Videos,Videos,Videos ..."
                )
            );
        }

        private void WrapAndRegisterViewModelAsDetailViewModel(IScreen screen)
        {
            RegisterDetailViewModel(
                new SimpleDetailViewModel(screen)
            );
        }
    }
}
