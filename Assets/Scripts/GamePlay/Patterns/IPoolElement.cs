using System;
using UnityEngine;

namespace GamePlay.Patterns
{
    public interface IPoolElement
    {
        void SetParentPool<T>(FlexibleMonoBehaviorPool<T> pool) where T : MonoBehaviour, IPoolElement;
        Action<Vector3> OnReleased { get; set; }
    }
}