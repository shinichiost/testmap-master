using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolFruits : MonoBehaviour
{
    public static ObjectPoolFruits instance;
    public int amountToPool = 20;
    [SerializeField]
    private List<GameObject> pooledfruits;
    [SerializeField]
    private GameObject fruitsprefab;

    
    private void Awake()
    {
        if(instance == null)
            instance = this;
    }
    void Start()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject obj = Instantiate(fruitsprefab);
            obj.SetActive(false);
            pooledfruits.Add(obj);
        }
    }

    
    public GameObject getpooledObject()
    {
        for(int i = 0; i < amountToPool; i++)
        {
            if (!pooledfruits[i].activeInHierarchy)
                return pooledfruits[i];
        }
        return null;
    }
}
