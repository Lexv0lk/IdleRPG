using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Atomic.Entities
{
    public abstract class SceneEntityInstallerBase : SerializedMonoBehaviour, IEntityInstaller
    {
#if UNITY_EDITOR
        internal Action mRefreshCallback;
#endif
        public abstract void Install(IEntity entity);
    }
}