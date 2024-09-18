using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine.SceneManagement;
using UnityEngine;


public class LoadingScreen : MonoBehaviour
{
    public static LoadingScreen instance;
    public float waitToLoad;
    public string LoadattavaScene;

    void Start()
    {
        instance = this;
    }

    void Update()
    {
        if (waitToLoad > 0)
        {
            waitToLoad -= Time.deltaTime;

            if (waitToLoad <= 0) 
            {
                SceneManager.LoadScene(LoadattavaScene);
            }
        }
    }
}
