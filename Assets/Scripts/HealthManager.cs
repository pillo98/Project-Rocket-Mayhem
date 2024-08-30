using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    private bool isImmune = false;
    [SerializeField] private int Health;
    [SerializeField]
    private float Iframeduration;
    [SerializeField]
    private float invincibilityDeltaTime;

    private IEnumerator BecomeImmune()
    {
        Debug.Log("Player turned Immune!");
        isImmune = true;

        for (float i = 0; i < Iframeduration; i += invincibilityDeltaTime)
        {
            yield return new WaitForSeconds(invincibilityDeltaTime);
        }

        isImmune = false;
        Debug.Log("Player is no longer Immune!");
    }

    public void TakeDamage(int amount)
    {
        if (isImmune) return;

        Health -= amount;

        if (Health <= 0)
        {
            Health = 0;
            return;
        }

        StartCoroutine(BecomeImmune());
    }
}
