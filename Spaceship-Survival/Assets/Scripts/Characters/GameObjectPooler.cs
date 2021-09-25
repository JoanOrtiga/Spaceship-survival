using System;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShipSurvival
{
    public class GameObjectPooler : MonoBehaviour
    {
        [SerializeField] private GameObject _objectToPool;
        private Queue<GameObject> _pooledObjects = new Queue<GameObject>();
        [SerializeField] private float _initialObjectCount = 5;

        private void Awake()
        {
            for (int i = 0; i < _initialObjectCount; i++)
            {
                _pooledObjects.Enqueue(CreateNewObject());
            }
        }

        public GameObject GetPooledObject()
        {
            if (_pooledObjects.Count > 0)
            {
                GameObject pooledObject = _pooledObjects.Dequeue();
                int counter = _pooledObjects.Count-1;
           
                while (pooledObject.activeSelf && counter > 0)
                {
                    _pooledObjects.Enqueue(pooledObject);
                
                    pooledObject = _pooledObjects.Dequeue();

                    counter--;
                }
            
                Debug.Log(pooledObject.activeSelf + " " + counter + " " + _pooledObjects.Count );

                if (!pooledObject.activeSelf)
                    return pooledObject;
            }
            
            return CreateNewObject();
        }

        public void ReturnToPool(GameObject toPool)
        {
            toPool.SetActive(false);
            _pooledObjects.Enqueue(toPool);
        }

        private GameObject CreateNewObject()
        {
            GameObject temp = Instantiate(_objectToPool, Vector3.zero, Quaternion.identity, transform);
            temp.SetActive(false);
            temp.GetComponent<PooledObject>().GameObjectPooler = this;
            return temp;
        }
    }
}
