using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyRocket : MonoBehaviour
{
    public GameObject Explosion;
    private void OnCollisionEnter(Collision collision)
    {


        if (collision.gameObject.CompareTag("Player") == false)
        {
            Instantiate(Explosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
