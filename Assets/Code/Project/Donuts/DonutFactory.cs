using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DonutFactory : MonoBehaviour
{
    [SerializeField] GameObject donutPrefab;

    public GameObject CreateDonut()
    {
        GameObject donut = Instantiate(donutPrefab);
        return donut;
    }
}
