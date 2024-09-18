using Leguar.LowHealth;
using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class HealthManager : MonoBehaviour
{
    private bool isImmune = false;
    [SerializeField] private int Health;
    [SerializeField]
    private float Iframeduration;
    [SerializeField]
    private float invincibilityDeltaTime;
    [SerializeField]
    LowHealthController HealthController;
    [SerializeField]
    GameObject GameOver;
    [SerializeField]
    TMP_Text GameOverScore;
    [SerializeField]
    ScoreManager ScoreManager;
    [SerializeField]
    PauseManager PauseManager;
    void Start()
    {
        Health = 100;
        
        HealthController.SetPlayerHealthInstantly(Health);
    }

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
        int newHealth = Health-amount;
        bool HealthDecreasing = (newHealth < Health);
        ChangeHealth(newHealth/100f, HealthDecreasing);
        Health -= amount;

        if (Health <= 0)
        {
            Health = 0;
            PauseManager.GamePaused = true;
            StarterAssetsInputs pInput = gameObject.GetComponent<StarterAssetsInputs>();
            pInput.cursorLocked = false;
            pInput.cursorInputForLook = false;
            Time.timeScale = 0;
            GameOverScore.text = $"Score So Far: {ScoreManager.Score}";
            GameOver.SetActive(true);
            return;
        }

        StartCoroutine(BecomeImmune());
    }

    public void ChangeHealth(float playerHPpercentage, bool HealthDecreasing) 
    {
        if (HealthDecreasing)
        {
            HealthController.SetPlayerHealthSmoothly(playerHPpercentage, 1f);
        }
        else
        {
            HealthController.SetPlayerHealthSmoothly(Health - playerHPpercentage, 1f);
        }
    }
}
