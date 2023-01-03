using System.Collections.Generic;
using StansAssets.Foundation.Patterns;
using UnityEngine;

namespace Modules.Core.Services.Pooling
{
    public class GameObjectsPool : IPoolingService
    {
        private readonly GameObject m_root;
        private readonly Dictionary<GameObject, ObjectPool<GameObject>> m_activePool = new Dictionary<GameObject, ObjectPool<GameObject>>();

        public GameObjectsPool(string name)
        {
            m_root = new GameObject(name);
            Object.DontDestroyOnLoad(m_root);
        }

        public GameObject Instantiate(GameObject origin)
        {
            return Instantiate(origin, Vector3.one, Quaternion.identity);
        }

        public GameObject Instantiate(GameObject origin, Vector3 position, Quaternion rotation)
        {
            var poolable = Instantiate<PoolableGameObject>(origin);
            var transform = poolable.transform;
            transform.position = position;
            transform.rotation = rotation;
            return poolable.gameObject;
        }

        public T Instantiate<T>(GameObject origin) where T : PoolableGameObject
        {
            var pool = GetPool(origin);
            var gameObject = pool.Get();
            var poolableObject = gameObject.GetComponent<PoolableGameObject>();
            poolableObject.Init(() =>
            {
                Release(origin, gameObject);
            });
            return (T)poolableObject;
        }

        void Release(GameObject origin, GameObject instance)
        {
            var pool = GetPool(origin);
            pool.Release(instance);
        }

        private ObjectPool<GameObject> GetPool(GameObject origin)
        {
            if (m_activePool.ContainsKey(origin))
            {
                return m_activePool[origin];
            }

            var pool = MakePool(origin);
            m_activePool.Add(origin, pool);
            return pool;
        }

        private ObjectPool<GameObject> MakePool(GameObject origin)
        {
            var pool = new ObjectPool<GameObject>(() => Object.Instantiate(origin),
                gameObject =>
                {
                    gameObject.SetActive(true);
                    gameObject.transform.SetParent(m_root.transform);
                }, gameObject =>
                {
                    gameObject.SetActive(false);
                    gameObject.transform.SetParent(m_root.transform);
                    gameObject.GetComponent<PoolableGameObject>().Release();
                });

            return pool;
        }
    }
}