using Modules.Core.Abstract;
using Modules.Core.Infrastructure;
using Modules.Core.Interfaces;
using Modules.Core.Services.Pooling;

namespace Modules.Core
{
    internal sealed class CoreModule : ApplicationModule
    {
        public override void Load()
        {
            Bind<ISceneService, IPreloadService>().ToConstant(new DefaultSceneLoadService());
            Bind<IPoolingService>().ToConstant(new GameObjectsPool("GameObjects Pool"));
        }
    }
}