using System;
using Modules.Core.Config;
using Modules.Core.Interfaces;
using StansAssets.SceneManagement;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;

namespace Modules.Core.Infrastructure
{
    public class DefaultSceneLoadService : SceneLoadService, IPreloadService
    {
        public IScenePreloader Preloader { get; private set; }

        public void PreparePreloader(Action onInit)
        {
            Load<DefaultPreloader>(AppConfig.DefaultPreloaderSceneName, (scene, sceneManager) =>
            {
                Preloader = sceneManager;
                Assert.IsNotNull(Preloader);

                onInit.Invoke();
            });
        }
    }
}