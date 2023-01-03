using System;

namespace Modules.Core.Interfaces
{
    internal interface IPreloadService : ISceneService
    {
        void PreparePreloader(Action onInit);
    }
}