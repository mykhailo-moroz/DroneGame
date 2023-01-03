using System;
using System.Collections.Generic;
using Modules.Core.Enums;
using StansAssets.SceneManagement;

namespace Modules.Core.Infrastructure
{
    public class PreloadManager : IApplicationStateDelegate<GameState>
    {
        readonly IScenePreloader m_Preloader;
        readonly List<GameState> m_StatesWithPreloaderRequired;

        public PreloadManager(IApplicationStateStack<GameState> stateStack, IScenePreloader preloader)
        {
            m_Preloader = preloader;
            stateStack.AddDelegate(this);

            stateStack.SetPreprocessAction(OnStackPreprocess);
            stateStack.SetPostprocessAction(OnStackPostprocess);
        }

        void OnStackPreprocess(StackOperationEvent<GameState> e, Action onComplete)
        {
            if (e.State.Equals(GameState.Game) || e.State.Equals(GameState.Menu))
            {
                m_Preloader.FadeIn(onComplete.Invoke);
            }
            else
            {
                onComplete.Invoke();
            }
        }

        void OnStackPostprocess(StackOperationEvent<GameState> e, Action onComplete)
        {
            if (e.State.Equals(GameState.Game) || e.State.Equals(GameState.Menu))
            {
                m_Preloader.FadeOut(onComplete.Invoke);
            }
            else
            {
                onComplete.Invoke();
            }
        }

        public void ApplicationStateWillChange(StackOperationEvent<GameState> e)
        {
            
        }

        public void ApplicationStateChangeProgressUpdated(float progress, StackChangeEvent<GameState> e)
        {
            
        }

        public void ApplicationStateChanged(StackOperationEvent<GameState> e) { }
        public void OnApplicationStateWillChanged(StackOperationEvent<GameState> e) { }

        public void ApplicationStateChangeProgressChanged(float progress, StackChangeEvent<GameState> e)
        {
            m_Preloader.OnProgress(progress);
        }
    }
}