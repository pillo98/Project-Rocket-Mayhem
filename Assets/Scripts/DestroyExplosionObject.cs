using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyExplosionObject : MonoBehaviour
{
    [SerializeField] private float onScreenDelay = 1f;
    public float radius = 5.0F;
    public float power = 10.0F;
    public Collider[] colliders;
    public Vector3 explosionPos;


    private void Start()
    {
        explosionPos = transform.position;
        colliders = Physics.OverlapSphere(explosionPos, radius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();

            if (rb != null)
                rb.AddExplosionForce(power, explosionPos, radius, 3.0F);
        }
        Destroy(gameObject, onScreenDelay);
    }
}
