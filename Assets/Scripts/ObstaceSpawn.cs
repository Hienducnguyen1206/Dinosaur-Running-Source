using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawn : MonoBehaviour
{
    [SerializeField] List<GameObject> Obstacles = new List<GameObject>();
    int RandomIndex;
    float delaytime;

    #region Singleton
    public static ObstacleSpawn Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
           
        }
        else
        {
            Destroy(gameObject);
        }
    }
    #endregion
    private void Start()
    {
        delaytime = 1.5f;
        StartCoroutine(SpawnObstacle());
        StartCoroutine(DecreaseDelaytime());
    }

    IEnumerator SpawnObstacle()
    {
        while (true)
        {
           
            RandomIndex = Random.Range(0,Obstacles.Count);
            GameObject obstacle = ObjectPooling.Instance.SpawnFromPool(Obstacles[RandomIndex]);
            obstacle.transform.position = gameObject.transform.position;
            yield return new WaitForSeconds(delaytime);
        }
    }

    IEnumerator DecreaseDelaytime()
    {
        while (delaytime>0.55f) {
            yield return new WaitForSeconds(25f);
            delaytime *= 0.95f;
        }
    }

    
   
}
