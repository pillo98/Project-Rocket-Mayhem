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
        Score += 1;
    }

    public void AddScore(int ScoreToAdd)
    {
        Score += ScoreToAdd;
    }
}
