using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackMoutainSpawn : MonoBehaviour
{
    [SerializeField] List<GameObject> backMoutainLists = new List<GameObject>();
    [SerializeField] List<GameObject> CloudLists = new List<GameObject>();
    int RandomIndex;
    int moutainDelayTime;
    int cloudyDelayTime;

    #region Singleton
    public static BackMoutainSpawn Instance;
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

        StartCoroutine(SpawnMoutain());
        StartCoroutine(SpawnCloud());
    }

    IEnumerator SpawnMoutain()
    {   
        yield return null;
        while (true)
        {
            moutainDelayTime = Random.Range(3, 12);
            RandomIndex = Random.Range(0, backMoutainLists.Count);
            GameObject obstacle = ObjectPooling.Instance.SpawnFromPool(backMoutainLists[RandomIndex]);
            obstacle.transform.position = gameObject.transform.position;
            yield return new WaitForSeconds(moutainDelayTime);
        }
    }

    IEnumerator SpawnCloud()
    {
        yield return null;
        while (true)
        {
            cloudyDelayTime = Random.Range(3, 12);
            RandomIndex = Random.Range(0, CloudLists.Count);
            GameObject obstacle = ObjectPooling.Instance.SpawnFromPool(CloudLists[RandomIndex]); 
            obstacle.transform.position = new Vector3(gameObject.transform.position.x, Random.Range(2,3.5f), 0);
            yield return new WaitForSeconds(cloudyDelayTime);
        }
    }


}
