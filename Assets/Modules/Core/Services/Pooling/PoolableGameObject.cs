using System;
using UnityEngine;

namespace Modules.Core.Services.Pooling
{
    public abstract class PoolableGameObject : MonoBehaviour
    {
        public abstract void Init(Action onRelease);

        public abstract void Release();
    }
}