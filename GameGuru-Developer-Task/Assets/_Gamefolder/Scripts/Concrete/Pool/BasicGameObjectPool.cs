using System.Collections.Generic;
using System.Linq;
using RoddGames.Abstracts.Patterns;
using UnityEngine;

namespace GameGuruDevChallange.Patterns
{
    public abstract class BasicGameObjectPool : MonoBehaviour
    {
        public GameObject prefab;
        public int poolSize = 10;

        Queue<GameObject> objectPool = new Queue<GameObject>();

        void Start()
        {
            InitializeObjectPool();
        }

        void InitializeObjectPool()
        {
            for (int i = 0; i < poolSize; i++)
            {
                GameObject obj = Instantiate(prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }
        }

        public GameObject GetObjectFromPool()
        {
            if (objectPool.Any())
            {
                GameObject obj = objectPool.Dequeue();
                obj.SetActive(true);
                return obj;
            }


            GameObject newObj = Instantiate(prefab);
            return newObj;
        }

        public void ReturnObjectToPool(GameObject obj)
        {
            obj.SetActive(false);
            objectPool.Enqueue(obj);
        }
    }
}