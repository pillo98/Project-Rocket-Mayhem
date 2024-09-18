using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class Cubespawner : MonoBehaviour
{
    [SerializeField]
    private GameObject currentObject;
    [SerializeField]
    private GameObject ObjectToSpawn;

    [SerializeField] private float cooldownTime = 2f;
    [SerializeField] private float lastUsedTime;

    private void Awake()
    {
        currentObject = Instantiate(ObjectToSpawn, transform.position, transform.rotation);
    }

    void Update()
    {
        if (Time.time > lastUsedTime + cooldownTime)
        {

            if (currentObject == null)
            {
                currentObject = Instantiate(ObjectToSpawn, transform.position, transform.rotation);

            }
            lastUsedTime = Time.time;
        }
    }
}
