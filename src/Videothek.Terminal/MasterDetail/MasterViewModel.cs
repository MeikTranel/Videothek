using Stylet;

namespace Videothek.Terminal.MasterDetail
{
    public abstract class MasterViewModel<T> : Conductor<IDetailViewModel<T>>.Collection.OneActive where T : class
    {
        public void DoActivateDetailViewModel(IDetailViewModel<T> detailViewModel)
        {
            ActivateItem(detailViewModel);
        }


        protected void RegisterDetailViewModel(IDetailViewModel<T> detailViewModel)
        {
            this.Items.Add(detailViewModel);
        }
    }
}
