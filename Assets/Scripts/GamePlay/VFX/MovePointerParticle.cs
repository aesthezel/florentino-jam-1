using System;
using System.Collections;
using GamePlay.Patterns;
using UnityEngine;

namespace GamePlay.VFX
{
    public class MovePointerParticle : MonoBehaviour, IPoolElement
    {
        [SerializeField] private ParticleSystem particle;
        
        private FlexibleMonoBehaviorPool<MovePointerParticle> _parentPool;
        public void SetParentPool<T>(FlexibleMonoBehaviorPool<T> pool) where T : MonoBehaviour, IPoolElement
        {
            _parentPool = pool as FlexibleMonoBehaviorPool<MovePointerParticle>;
        }

        public Action<Vector3> OnReleased { get; set; }
        
        private void OnEnable()
        {
            particle.Play();
            StartCoroutine(ReturnToPoolAfterParticles());
        }

        private void OnDisable()
        {
            particle.Stop();
        }
        
        private IEnumerator ReturnToPoolAfterParticles()
        {
            var totalDuration = particle.main.duration + particle.main.startLifetime.constantMax;
            yield return new WaitForSeconds(totalDuration);
            
            _parentPool.ReleaseObject(this);
        }
    }
}