using System;
using Modules.Core.Enums;
using Modules.Core.Static;
using StansAssets.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Modules.UI.Gameplay
{
    public class GamePlayUIController : MonoBehaviour, IGamePlayUIController, ISceneManager, ISceneDelegate
    {
        [SerializeField]
        private GameObject m_gameplayUI;
        [SerializeField]
        private Button m_pauseButton;
        
        private void Awake()
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        
        public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            m_pauseButton.onClick.AddListener(() =>
            {
                App.State.Set(GameState.Menu);
            });
        }

        public void OnSceneUnload()
        {
            
        }

        public void ActivateScene(Action onComplete)
        {
            m_gameplayUI.SetActive(true);
            onComplete.Invoke();
        }

        public void DeactivateScene(Action onComplete)
        {
            m_gameplayUI.SetActive(false);
            onComplete.Invoke();
        }
    }
}