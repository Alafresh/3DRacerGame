using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platformPrefab;
    public Transform lastPlatform;
    Vector3 lastPosition;
    Vector3 newPos;
    // Start is called before the first frame update
    void Start()
    {
        lastPosition = lastPlatform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
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
