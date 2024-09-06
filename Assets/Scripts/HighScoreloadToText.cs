using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;
using UnityEngine.SceneManagement;

public class HighScoreloadToText : MonoBehaviour
{
    [SerializeField]
    private string Scene;
    private string Score;
    private TMP_Text text;

    private void Awake()
    {
        if (Scene != null)
        {

            string filePath = $"{Application.dataPath}/{Scene}-HighScore.json";

            Score = File.ReadAllText(filePath);

            text = this.gameObject.GetComponent<TMP_Text>();

            text.text = $"HighScore:{Score}";
        }
    }
}
