using System;
using Modules.Core.Enums;
using Modules.Core.Static;
using StansAssets.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Modules.UI.MainMenu
{
    public class MainMenuController : MonoBehaviour, IMainMenuController, ISceneManager, ISceneDelegate
    {
        [SerializeField]
        private Button m_playButton;
        [SerializeField]
        private Button m_exitButton;

        [SerializeField]
        private GameObject m_mainMenu;

        private void Awake()
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            m_playButton.onClick.AddListener(() =>
            {
                App.State.Set(GameState.Game);
            });
            
            m_exitButton.onClick.AddListener(() =>
            {
                App.State.Set(GameState.Exit);
            });
        }

        public void OnSceneUnload()
        {
            
        }

        public void ActivateScene(Action onComplete)
        {
            m_mainMenu.SetActive(true);
            onComplete.Invoke();
        }

        public void DeactivateScene(Action onComplete)
        {
            m_mainMenu.SetActive(false);
            onComplete.Invoke();
        }
    }
}