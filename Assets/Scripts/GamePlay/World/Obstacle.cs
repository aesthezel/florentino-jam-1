using UnityEngine;

namespace GamePlay.World
{
    public class Obstacle : MonoBehaviour, IDamageable
    {
        public void Damage(float value)
        {
            Debug.Log("Invensible");
        }
    }
}