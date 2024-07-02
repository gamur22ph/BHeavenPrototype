using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool SharedInstance;
    
    [System.Serializable]
    private class ObjectToPool
    {
        public List<GameObject> pooledObjects;
        public GameObject objectPrefab;
        public int amountToPool;
    }

    [SerializeField] List<ObjectToPool> objectsToPool;

    void Awake()
    {
        SharedInstance = this;
    }

    void Start()
    {
        foreach(ObjectToPool objectToPool in objectsToPool)
        {
            objectToPool.pooledObjects = new List<GameObject>();
            GameObject tmp;
            for (int i = 0; i < objectToPool.amountToPool; i++)
            {
                tmp = Instantiate(objectToPool.objectPrefab);
                tmp.SetActive(false);
                objectToPool.pooledObjects.Add(tmp);
            }

        }
    }

    public GameObject GetPooledObject(int idx)
    {
        for (int i = 0; i < objectsToPool[idx].amountToPool; i++)
        {
            if (!objectsToPool[idx].pooledObjects[i].activeInHierarchy)
            {
                return objectsToPool[idx].pooledObjects[i];
            }
        }
        return null;
    }
}
