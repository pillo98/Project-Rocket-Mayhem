using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField]
    int Damage;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            HealthManager Php = other.gameObject.GetComponent<HealthManager>();

            Php.TakeDamage(Damage);

            Destroy(gameObject);
        }
    }
}
