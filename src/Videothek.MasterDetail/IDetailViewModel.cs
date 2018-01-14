using Stylet;

namespace Videothek.MasterDetail
{
    public interface IDetailViewModel : IScreen
    {
        IScreen Screen { get; }
        string FullName { get; }
    }
}
