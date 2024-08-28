using StarterAssets;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MovePlayerWithUnderObject : MonoBehaviour
{

    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player") == true)
        {

            col.transform.SetParent(transform);
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.CompareTag("Player") == true)
        {

            col.transform.SetParent(null);
        }
    }
}
