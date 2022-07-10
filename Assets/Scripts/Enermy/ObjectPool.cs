using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance;
    public List<GameObject> pooledObjects;
    [SerializeField] private GameObject bulletprefab;
    private int amountToPool = 20;
    public Transform Bullet;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        for(int i = 0; i < amountToPool; i++)
        {
            GameObject obj = Instantiate(bulletprefab,Bullet);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
    }
    public GameObject getPooledObject()
    {
        for(int i = 0; i < amountToPool; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
                return pooledObjects[i];
        }
        return null;
    }
    
    void Update()
    {
        
    }
}
