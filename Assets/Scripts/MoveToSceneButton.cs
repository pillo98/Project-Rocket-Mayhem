using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveToSceneButton : MonoBehaviour
{
    public string NextScene;

    public void MoveToScene()
    {
        SceneManager.LoadScene(NextScene);
    }
}
