using MikeAssets.ModularServiceLocator.Runtime;
using Modules.Core.Enums;
using Modules.Core.Interfaces;
using Modules.Core.Static;
using StansAssets.SceneManagement;

namespace Modules.Core.States
{
    public abstract class ApplicationState : IApplicationState<GameState>
    {
        readonly SceneActionsQueue m_SceneActionsQueue;

        protected ApplicationState()
        {
            var sceneService = App.Services.Get<ISceneService>();
            m_SceneActionsQueue = new SceneActionsQueue(sceneService);
        }

        protected void AddSceneAction(SceneActionType type, string sceneName)
        {
            m_SceneActionsQueue.AddAction(type, sceneName);
        }
        
        protected abstract void OnChangeState(StackChangeEvent<GameState> evt, IProgressReporter reporter);
        public void ChangeState(StackChangeEvent<GameState> evt, IProgressReporter reporter) {
            OnChangeState(evt, reporter);
            m_SceneActionsQueue.Start(reporter.UpdateProgress, reporter.SetDone);
        }
    }
}