using StansAssets.SceneManagement;

namespace Modules.Core.Interfaces
{
    public interface ISceneService : ISceneLoadService
    {
        IScenePreloader Preloader { get; }
    }
}