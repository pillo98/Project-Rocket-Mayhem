using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanUp : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") != true)
        {
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Player") && other.gameObject.name == "PlayerCapsule")
        {
            HealthManager hp = other.GetComponent<HealthManager>();
            hp.TakeDamage(100);
        }
    }
}
