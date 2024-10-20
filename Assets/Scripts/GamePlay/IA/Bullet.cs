using System;
using UnityEngine;

namespace GamePlay.IA
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] 
        private float speed;
        private void Update()
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }
}
