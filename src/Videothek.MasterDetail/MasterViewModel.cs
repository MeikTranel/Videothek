using Stylet;

namespace Videothek.MasterDetail
{
    public abstract class MasterViewModel : Conductor<IDetailViewModel>.Collection.OneActive
    {
        public void DoActivateDetailViewModel(IDetailViewModel detailViewModel)
        {
            ActivateItem(detailViewModel);
        }


        public void RegisterSimpleDetailViewModel(IScreen screen,string fullName,string shortName)
        {
            this.Items.Add(
                    new SimpleDetailViewModel(
                        screen,
                        fullName,
                        shortName
                    )
                );
        }
    }
}
