using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BitcoinBehavior : MonoBehaviour
{
    Vector3 position;
    bool destroyState = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (destroyState)
        {

            transform.Rotate(Vector3.forward, 90 * Time.deltaTime);
            transform.Translate(new Vector3(0, 16, 0) * Time.deltaTime, Space.World);

        }
        else
        {
            transform.Rotate(Vector3.forward, 90 * Time.deltaTime);

        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            destroyState = true;
            Invoke("EventualDestroy", .14f);
        }
    }

    void EventualDestroy()
    {
        gameObject.SetActive(false);
        Database.bitcoin += 1;
        Destroy(gameObject, 0.5f);
    }

}
