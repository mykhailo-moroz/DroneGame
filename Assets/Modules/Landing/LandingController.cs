using MikeAssets.ModularServiceLocator.Runtime;
using Modules.Core.Config;
using Modules.Core.Enums;
using Modules.Core.Interfaces;
using Modules.Core.Static;
using UnityEngine;

namespace Modules.Landing
{
    public class LandingController : MonoBehaviour
    {
        private void Start()
        {
            App.Init(() =>
            {
                App.State.Set(GameState.Menu);
                
                var sceneService = App.Services.Get<ISceneService>();
                sceneService.Unload(AppConfig.LandingSceneName, null);
            });
        }
    }    
}


