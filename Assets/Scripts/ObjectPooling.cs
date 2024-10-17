using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour 
{
    #region Singleton
    public static ObjectPooling Instance;

    private void Awake()
    {
        Instance = this;



        foreach (var obj in Objects)
        {
            Queue<GameObject> queue = new Queue<GameObject>();
            Pools.Add(obj.tag, queue);
        }

    }
    #endregion


    [SerializeField]
    List<GameObject> Objects = new List<GameObject>();
    Dictionary<string, Queue<GameObject>> Pools = new Dictionary<string, Queue<GameObject>>();



    private void Start()
    {
        
    }

    public GameObject SpawnFromPool(GameObject obj)
    {
      
        if (Pools.ContainsKey(obj.tag))
        {
            if (Pools[obj.tag].Count > 0)
            {            
                GameObject objToSpawn = Pools[obj.tag].Dequeue();      
                objToSpawn.SetActive(true);            
                return objToSpawn;
            }
            else {
               
                GameObject objToSpawn = Instantiate(obj);
                objToSpawn.SetActive(true);
                return objToSpawn;
            }
        }else
        {
           
            return null;
        }
    }

    public void ReturnToPool(GameObject obj)
    {
       
        if (Pools.ContainsKey(obj.tag)) {
            obj.SetActive(false);
            Pools[obj.tag].Enqueue(obj);
        }
        else
        {
            return;
        }
    }
}
