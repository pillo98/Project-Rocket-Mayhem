using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DestroyExplosionObject : MonoBehaviour
{
    [SerializeField] private float onScreenDelay = 1f;
    public float radius = 5.0F;
    public float power = 10.0F;
    public Collider[] colliders;
    public Vector3 explosionPos;
    private ExplosionForceReceiver PlayerForceReceiveer;


    private void Start()
    {
        explosionPos = transform.position;
        colliders = Physics.OverlapSphere(explosionPos, radius);
        foreach (Collider hit in colliders)
        {
            Break Break = hit.gameObject.GetComponent<Break>();

            if (Break != null)
            {
                Break.BreakObject();
            }
        }
        colliders = Physics.OverlapSphere(explosionPos, radius);
        foreach (Collider hit in colliders)
        {
            if (hit.gameObject.CompareTag("Player") && hit.gameObject.name == "PlayerCapsule")
            {
                PlayerForceReceiveer = hit.gameObject.GetComponent<ExplosionForceReceiver>();
                Vector3 dir = hit.transform.position - explosionPos;
                PlayerForceReceiveer.AddExplosionForce(dir, power);
            }
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null)
                rb.AddExplosionForce(power, explosionPos, radius, 3.0F);
        }
        Destroy(gameObject, onScreenDelay);
    }
}
