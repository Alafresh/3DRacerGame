using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarSelection : MonoBehaviour
{
    [SerializeField] Button nextCar;
    [SerializeField] Button previousCar;
    [SerializeField] CameraFollow cameraFollow;
    private int currentCar;

    private void Awake()
    {
        SelectCar(0);
    }

    private void SelectCar(int index)
    {
        previousCar.interactable = (index != 0);
        nextCar.interactable = (index != transform.childCount - 1);
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(i == index);
            cameraFollow.target = transform.GetChild(currentCar);
        }
    }
    public void ChangeCar(int change)
    {
        currentCar += change;
        SelectCar(currentCar);
    }
}
