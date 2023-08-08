using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Invoke("Fall", 0.2f);
        }
    }
    void Fall()
    {
        GetComponent<Rigidbody>().isKinematic = false;
        DestroyObject(gameObject, 1f);
    }
}
