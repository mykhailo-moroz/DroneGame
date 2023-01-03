using System;
using Modules.Core.Config;
using Modules.Core.Enums;
using StansAssets.SceneManagement;
using UnityEngine;

namespace Modules.Core.States
{
    public class GameAppState : ApplicationState
    {
        protected override void OnChangeState(StackChangeEvent<GameState> evt, IProgressReporter reporter)
        {
            switch (evt.Action)
            {
                case StackAction.Added:
                    AddSceneAction(SceneActionType.Load, AppConfig.TestLevelSceneName);
                    break;
                case StackAction.Removed:
                    AddSceneAction(SceneActionType.Unload, AppConfig.TestLevelSceneName);
                    break;
                case StackAction.Paused:
                    Time.timeScale = 0f;
                    break;
                case StackAction.Resumed:
                    Time.timeScale = 1f;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(evt.Action), evt.Action, null);
            }
        }
    }
}