using UnityEngine;
using System.Collections.Generic;

public class PlatformPool : MonoBehaviour
{
    [SerializeField] GameObject platformPrefab;
    [SerializeField] int poolSize = 10;

    Queue<GameObject> platformPool = new Queue<GameObject>();

    void Awake()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject platform = Instantiate(platformPrefab);
            platform.SetActive(false);
            platformPool.Enqueue(platform);
        }
    }

    public GameObject GetPlatform()
    {
        if (platformPool.Count > 0)
        {
            GameObject platform = platformPool.Dequeue();
            platform.SetActive(true);
            if(platform.transform.childCount > 0)
            {
                platform.transform.GetChild(0).gameObject.SetActive(true);
            }
            return platform;
        }
        else
        {
            GameObject platform = Instantiate(platformPrefab);
            return platform;
        }
    }

    public void ReturnPlatform(GameObject platform)
    {
        platform.SetActive(false);
        platformPool.Enqueue(platform);
        platform.GetComponent<Rigidbody>().isKinematic = true;
    }
}