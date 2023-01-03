namespace Modules.Core.Interfaces
{
    public interface IReadOnlyServiceLocator
    {
        TInterface Get<TInterface>();
    }
}