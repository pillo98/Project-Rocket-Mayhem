using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int Score;
    public float CompletionTime;


    void Update()
    {
        CompletionTime += Time.deltaTime;
    }

    public void AddScore(int ScoreToAdd)
    {
        Score += ScoreToAdd;
    }
}
