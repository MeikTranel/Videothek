using System;
using Stylet;
using Videothek.Terminal.MasterDetail;

namespace Videothek.Terminal.ViewModels
{
    public class SimpleDetailViewModel : IDetailViewModel<IScreen>
    {
        public SimpleDetailViewModel(IScreen viewModel) => ViewModel = viewModel ?? throw new ArgumentNullException(nameof(viewModel));

        public string Name => ViewModel.DisplayName;
        public IScreen ViewModel { get; }
    }
}
