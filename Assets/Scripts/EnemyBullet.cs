using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField]
    int Damage;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && other.gameObject.name == "PlayerCapsule")
        {
            HealthManager Php = other.gameObject.GetComponent<HealthManager>();

            Php.TakeDamage(Damage);

            Destroy(gameObject);
        }
        else if (other.CompareTag("Enemy") != true)
        {
            Destroy(gameObject);
        }
    }
}
