using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;
using UnityEngine.SceneManagement;

public class WinManager : MonoBehaviour
{
    [SerializeField]
    private ScoreManager scoreManager;
    [SerializeField]
    private TMP_Text ScoreText;
    [SerializeField]
    private GameObject WinScreen;
    [SerializeField]
    private string CurrentScene;

    private Dictionary<string, int> highScore = new Dictionary<string, int>();

    private void Awake()
    {
        CurrentScene = SceneManager.GetActiveScene().ToString();
    }

    private void OnCollisionEnter(Collision collision)
    {
        StarterAssetsInputs pInput = collision.gameObject.GetComponent<StarterAssetsInputs>();
        pInput.cursorLocked = false;
        pInput.cursorInputForLook = false;
        Time.timeScale = 0;
        WinScreen.SetActive(true);

        ScoreText.text = "Score: " + scoreManager.Score;

        SaveHighScore(highScore);
    }

    public void SaveHighScore(Dictionary<string, int> highScore)
    {
        string json = JsonConvert.SerializeObject(scoreManager.Score);

        string filePath = $"{Application.dataPath}/HighScores.json";

        File.WriteAllText(filePath, json);
    }
}
