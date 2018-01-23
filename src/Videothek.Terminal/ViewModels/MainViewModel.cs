using Stylet;

namespace Videothek.Terminal.ViewModels
{
    public class MainViewModel : Conductor<IScreen>.Collection.OneActive
    {
        public MainViewModel()
        {
            RegisterDetailViewModel(
                new TestScreenViewModel(
                    "AOE",
                    "WOLOLOLOLOLOLOLO"
                )
            );
            RegisterDetailViewModel(
                new TestScreenViewModel(
                    "Videos",
                    "Videos,Videos,Videos ..."
                )
            );
        }


        public void DoActivateDetailViewModel(IScreen detailViewModel)
        {
            this.ActivateItem(detailViewModel);
        }


        private void RegisterDetailViewModel(IScreen detailViewModel)
        {
            this.Items.Add(detailViewModel);
        }
    }
}
