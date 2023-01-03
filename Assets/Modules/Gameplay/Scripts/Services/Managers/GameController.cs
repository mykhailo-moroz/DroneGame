using System;
using MikeAssets.ModularServiceLocator.Runtime;
using Modules.Core.Config;
using Modules.Core.Infrastructure;
using Modules.Core.Interfaces;
using Modules.Core.Static;
using StansAssets.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Modules.Gameplay.Scripts.Services.Managers
{
    internal class GameController : MonoBehaviour, IGameController, ISceneManager, ISceneDelegate
    {
        private string m_gameplayModuleName = "GamePlay";

        private void Awake()
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
            SceneManager.sceneUnloaded += OnSceneUnload;
        }
        
        public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            var sceneService = App.Services.Get<ISceneService>();
            sceneService.Load<DefaultPreloader>(AppConfig.GamePlayUISceneName, (gameScene, loader) => { Debug.Log("Gameplay UI loaded"); });
        }

        public void OnSceneUnload(Scene scene)
        {
            var sceneService = App.Services.Get<ISceneService>();
            sceneService.Unload(AppConfig.GamePlayUISceneName, () => { Debug.Log("Gameplay UI unloaded"); });
        }

        public void ActivateScene(Action onComplete)
        {
            onComplete.Invoke();
        }

        public void DeactivateScene(Action onComplete)
        {
            onComplete.Invoke();
        }
    }

    internal interface IGameController
    {
    }
}