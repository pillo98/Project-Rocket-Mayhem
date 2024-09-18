using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Break : MonoBehaviour
{
    [SerializeField] private GameObject BrokenVariant;
    [SerializeField] ScoreManager scoreManager;
    [SerializeField] int ScoreGain;
    private bool instantiated = false;
    public void BreakObject()
    {
        if (scoreManager != null)
        { scoreManager.Score += ScoreGain; }
        if (instantiated == false )
        {
            Instantiate(BrokenVariant, transform.position, transform.rotation);
            instantiated = true;
        }

        Destroy(gameObject);
    }
}
