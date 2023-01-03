using System;
using Modules.Core.Config;
using Modules.Core.Enums;
using StansAssets.SceneManagement;

namespace Modules.Core.States
{
    public class MenuAppState : ApplicationState
    {
        protected override void OnChangeState(StackChangeEvent<GameState> evt, IProgressReporter reporter)
        {
            switch (evt.Action)
            {
                case StackAction.Added:
                    AddSceneAction(SceneActionType.Load, AppConfig.MainMenuSceneName);
                    break;
                case StackAction.Removed:
                    AddSceneAction(SceneActionType.Deactivate, AppConfig.MainMenuSceneName);
                    break;
                case StackAction.Paused:
                    break;
                case StackAction.Resumed:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(evt.Action), evt.Action, null);
            }           
        }
    }
}