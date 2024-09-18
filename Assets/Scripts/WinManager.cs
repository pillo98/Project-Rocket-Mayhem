using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem.Controls;

public class WinManager : MonoBehaviour
{
    [SerializeField]
    private ScoreManager scoreManager;
    [SerializeField]
    private TMP_Text ScoreText;
    [SerializeField]
    private TMP_Text TimeText;
    [SerializeField]
    private GameObject WinScreen;
    [SerializeField]
    private string CurrentScene;
    [SerializeField]
    private int ScoreMedian;
    private void Awake()
    {
        CurrentScene = SceneManager.GetActiveScene().name;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            scoreManager.Score += ScoreMedian / (int)scoreManager.CompletionTime;
            StarterAssetsInputs Input = collision.gameObject.GetComponent<StarterAssetsInputs>();
            Input.cursorLocked = false;
            Input.cursorInputForLook = false;
            Time.timeScale = 0;
            WinScreen.SetActive(true);


            ScoreText.text = "Score: " + scoreManager.Score;
            TimeText.text = "Timee: " + scoreManager.CompletionTime;
            SaveHighScore();
        }
    }

    public void SaveHighScore()
    {
        string json = JsonConvert.SerializeObject(scoreManager.Score);

        string filePath = $"{Application.dataPath}/{CurrentScene}-HighScore.json";

        if (File.Exists(filePath)) 
        { 
            string HighScoreString = File.ReadAllText(filePath);

            int HighScore = int.Parse(HighScoreString);

            if (HighScore < scoreManager.Score) 
            {
                File.WriteAllText(filePath, json);
                Debug.Log("High Score beaten");
            }
            else
            {
                Debug.Log("High Score Not beaten");
            }
        }
        else
        {
            File.WriteAllText(filePath, json);
            Debug.Log("File created");
        }
    }
}
