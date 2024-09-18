using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionForceReceiver : MonoBehaviour
{
    [SerializeField]float mass = 90.0F;
    Vector3 impact = Vector3.zero;
    private CharacterController character;
    void Start()
    {
        character = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (impact.magnitude > 0.2F) character.Move(impact * Time.deltaTime);
        impact = Vector3.Lerp(impact, Vector3.zero, 5 * Time.deltaTime);
    }
    public void AddExplosionForce(Vector3 dir, float force)
    {
        dir.y *= 3;
        dir.Normalize();
        impact += dir.normalized * force / mass;
    }
}
