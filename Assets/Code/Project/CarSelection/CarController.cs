using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] GameObject pickUpEffect;
    bool movingLeft = true;
    bool firstInput = true;
    
    // Update is called once per frame
    void Update()
    {
        if( GameManager.instance.gameStarted)
        {
            if (!GameManager.instance.gameIsPaused)
            {
                Move();
                CheckInput();
            }
        }
        if (transform.position.y < -2)
        {
            GameManager.instance.GameOver();
        }
    }

    public void Move()
    {
        transform.position += transform.forward * Time.deltaTime * speed;
    }
    void CheckInput()
    {
        if(firstInput)
        {
            firstInput = false;
            return;
        }
        if (Input.GetMouseButtonDown(0))
        {
            ChangeDirection();
        }
    }
    public void ChangeDirection()
    {
        if (movingLeft)
        {
            movingLeft = false;
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        else
        {
            movingLeft = true;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Donut")
        {
            GameManager.instance.IncrementScore();

            Instantiate(pickUpEffect, other.transform.position, pickUpEffect.transform.rotation);
            other.gameObject.SetActive(false);
        }
    }
}
