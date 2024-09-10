using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private RaycastHit hit;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Bit shift the index of the layer (8) to get a bit mask
            int layerMask = 1 << 6;
            layerMask = ~layerMask;
            RaycastHit hit;
            if (Physics.Raycast(transform.position, other.gameObject.transform.position - transform.position, out hit, Mathf.Infinity, layerMask))
            {
                Debug.DrawRay(transform.position, other.gameObject.transform.position - transform.position, Color.yellow);
                Debug.Log("Did Hit");
            }
            else
            {
                Debug.DrawRay(transform.position, other.gameObject.transform.position - transform.position * 1000, Color.white);
                Debug.Log("Did not Hit");
            }
        }
    }
}
