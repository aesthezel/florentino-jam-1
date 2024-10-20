using UnityEngine;
using UnityEngine.Pool;

namespace GamePlay.Patterns
{
    public class FlexibleMonoBehaviorPool<T> where T : MonoBehaviour, IPoolElement
    {
        T prefab;
        ObjectPool<T> pool;
        int defaultSize;
        int maxSize;

        public FlexibleMonoBehaviorPool(T prefab, int defaultSize = 20, int maxSize = 100)
        {
            this.prefab = prefab;  // The prefab to spawn.
            this.defaultSize = defaultSize;  // Pool's starting number of objects.
            this.maxSize = maxSize;  // Max size for our pool.
            // Initializing our pool.
            pool = new ObjectPool<T>(
                CreatePooledObject,
                OnGetFromPool,
                OnReturnToPool,
                OnDestroyPooledObject,
                true,
                defaultSize,
                maxSize
            );
        }
        
        public T GetObject(Vector3 position)
        {
            T obj = pool.Get();
            obj.transform.position = position;
            return obj;
        }
        
        public T GetObject(Vector3 position, Quaternion rotation)
        {
            T obj = pool.Get();
            obj.transform.position = position;
            obj.transform.rotation = rotation;
            return obj;
        }
        
        public void ReleaseObject(T obj)
        {
            pool.Release(obj);
        }
        
        private T CreatePooledObject()
        {
            T newObject = Object.Instantiate(prefab);
            newObject.SetParentPool(this);
            return newObject;
        }
        
        private void OnGetFromPool(T pooledObject)
        {
            pooledObject.gameObject.SetActive(true);
        }
        
        private void OnReturnToPool(T pooledObject)
        {
            pooledObject.gameObject.SetActive(false);
        }
        
        private void OnDestroyPooledObject(T pooledObject)
        {
            Object.Destroy(pooledObject);
        }
    }
}