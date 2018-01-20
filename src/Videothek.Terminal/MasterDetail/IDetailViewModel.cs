namespace Videothek.Terminal.MasterDetail
{
    public interface IDetailViewModel<T> where T : class
    {
        string Name { get; }
        T ViewModel { get; }
    }
}
