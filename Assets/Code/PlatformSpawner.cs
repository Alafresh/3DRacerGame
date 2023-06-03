using UnityEngine;
using System.Collections;

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField] GameObject platformPrefab;
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

    // Update is called once per frame
    void Update()
    {
       
    }

    IEnumerator SpawnPlatforms()
    {
        while(!stop)
        {
            GeneratePosition();
            Instantiate(platformPrefab, newPos, Quaternion.identity);
            lastPosition = newPos;
            yield return new WaitForSeconds(0.1f);
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
