using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreToSigns : MonoBehaviour
{
    [SerializeField]
    ScoreManager scoreManager;
    [SerializeField]
    TMP_Text text;
    void Update()
    {
        text.text = $"Your current score is: {scoreManager.Score}";
    }
}
