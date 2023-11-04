using UnityEngine;
using System.Collections;

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField] PlatformPool platformPool;
    [SerializeField] Transform lastPlatform;
    Vector3 lastPosition;
    Vector3 newPos;

    bool stop;

    // Start is called before the first frame update
    void Start()
    {
        lastPosition = lastPlatform.position;
        StartCoroutine(SpawnPlatforms());
    }

    IEnumerator SpawnPlatforms()
    {
        while(!stop)
        {
            GeneratePosition();
            GameObject platform = platformPool.GetPlatform();
            platform.transform.position = newPos;
            //Instantiate(platformPrefab, newPos, Quaternion.identity);
            lastPosition = newPos;
            yield return new WaitForSeconds(0.25f);
        }
    }

    void GeneratePosition()
    {        
        newPos = lastPosition;

        int rand = Random.Range(0, 2);

        if (rand > 0)
        {
            newPos.x += 2f;
        }
        else
        {
            newPos.z += 2f;
        }
    }
}
