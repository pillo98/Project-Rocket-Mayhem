using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Break : MonoBehaviour
{
    public GameObject BrokenVariant;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") == true)
        {
            Instantiate(BrokenVariant, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
