using UnityEngine;

namespace Gameplay.IA.Interactions
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField] private GameObject bullet;
        [SerializeField] private float fireRate;
        [SerializeField] private Transform firePoint;
        private float lastShoot;

        public void Shoot()
        {
            if (Time.time - lastShoot < fireRate) return;
            lastShoot = Time.time;
            
            Instantiate(bullet, firePoint.position, transform.rotation);
        }
    }
}