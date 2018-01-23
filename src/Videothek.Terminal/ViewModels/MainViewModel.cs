using Stylet;
using Videothek.Core;
using Videothek.Terminal.MasterDetail;

namespace Videothek.Terminal.ViewModels
{
    public class MainViewModel : MasterViewModel<IScreen>
    {
        public MainViewModel()
        {
            WrapAndRegisterViewModelAsDetailViewModel(
                new VideoViewModel(
                    new Video()
                    {
                        Name = "Boondock Saints",
                        Availability = 123,
                        Price  = 13.37f,
                        CoverImageLocation = ""
                    }
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
