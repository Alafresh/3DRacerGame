using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] GameObject donut;
    // Start is called before the first frame update
    void Start()
    {
        int randDonut = Random.Range(0, 5);
        Vector3 donutPos = transform.position;
        donutPos.y += 1f;
        if (randDonut < 1)
        {
            GameObject donutInstance = Instantiate(donut, donutPos, donut.transform.rotation);
            donutInstance.transform.SetParent(gameObject.transform);
        }
        // 1 2 3 4 Dont spawn the donut
    }
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
        Destroy(gameObject, 1f);
    }
}
