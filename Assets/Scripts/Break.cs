using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Break : MonoBehaviour
{
    [SerializeField] private GameObject BrokenVariant;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") == false && collision.gameObject.CompareTag("Player") == false)
        {
            Instantiate(BrokenVariant, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
