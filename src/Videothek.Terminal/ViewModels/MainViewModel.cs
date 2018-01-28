using Stylet;
using Videothek.Core;

namespace Videothek.Terminal.ViewModels
{
    public class MainViewModel : Conductor<IScreen>.Collection.OneActive
    {
        public VideoViewModel VideoViewModel => new VideoViewModel( new Video()
        {
            Availability = 123,
            CoverImageLocation = "",
            ID = 12,
            Name = "Boondock Saints",
            Price = 123.53f
        });

        public void ActivateScreen(Screen screen)
        {
            this.ActivateItem(screen);
        }
    }
}
