using System;
using System.Collections;
using GamePlay.Patterns;
using GamePlay.Teams;
using GamePlay.World;
using UnityEngine;

namespace GamePlay.Weapons
{
    public class Bullet : MonoBehaviour, IPoolElement
    {
        [SerializeField] 
        private float speed = 10f;
        [SerializeField] 
        private float damage = 10f;
        [SerializeField] 
        private float lifeTime = 5f;
        [SerializeField] 
        private ScriptableEnumTeam teamIgnore;

        private FlexibleMonoBehaviorPool<Bullet> _parentPool;
        
        public Action<Vector3> OnReleased { get; set; }
        public void SetParentPool<T>(FlexibleMonoBehaviorPool<T> pool) where T : MonoBehaviour, IPoolElement
        {
            _parentPool = pool as FlexibleMonoBehaviorPool<Bullet>;
        }

        private void Update()
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        
        private void OnTriggerEnter(Collider other)
        {
            Debug.Log($"{transform.name } collide with {other.name}");
            // Verificar si el objeto colisionado implementa IDamageable
            ITeam team = other.GetComponent<ITeam>();
            if (team?.Team == teamIgnore) return;
            
            IDamageable damageable = other.GetComponent<IDamageable>();
            if (damageable != null)
            {
                // Infligir daño
                damageable.Damage(damage);
                OnReleased?.Invoke(transform.position);
                _parentPool.ReleaseObject(this);
            }
        }
        
        private void OnEnable()
        {
            StartCoroutine(ReturnToPoolAfterTime());
        }
        
        private IEnumerator ReturnToPoolAfterTime()
        {
            yield return new WaitForSeconds(lifeTime);
            _parentPool.ReleaseObject(this);
        }
    }
}
