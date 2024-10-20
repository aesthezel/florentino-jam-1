using GamePlay.Patterns;
using GamePlay.VFX;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;

namespace GamePlay.Weapons
{
    public class Weapon : MonoBehaviour
    {
        [Title("Prefabs")]
        [SerializeField] private Bullet bulletPrefab;
        [SerializeField] private BulletParticle bulletParticlePrefab;
        
        [SerializeField] private float fireRate;
        [SerializeField] private Transform firePoint;
        private float lastShoot;

        private FlexibleMonoBehaviorPool<Bullet> bulletPool;
        private FlexibleMonoBehaviorPool<BulletParticle> bulletParticlePool;

        private void Start()
        {
            bulletPool = new FlexibleMonoBehaviorPool<Bullet>(bulletPrefab, 10, 100);
            bulletParticlePool = new FlexibleMonoBehaviorPool<BulletParticle>(bulletParticlePrefab, 10, 100);
        }

        public void Shoot()
        {
            if (Time.time - lastShoot < fireRate) return;
            lastShoot = Time.time;

            var bullet = bulletPool.GetObject(firePoint.position, firePoint.rotation);
            bullet.OnReleased += ShowParticle;
        }

        private void ShowParticle(Vector3 position)
        {
            Debug.Log("Ejecutando particulas");
            bulletParticlePool.GetObject(position);
        }
    }
}