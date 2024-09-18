using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameButton : MonoBehaviour
{
    [SerializeField]
    private GameObject gameObjectToEnable;
    [SerializeField]
    private bool EnableOrDisable;
    [SerializeField]
    private Material PressedMat;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CanButton"))         
        {
            gameObjectToEnable.SetActive(EnableOrDisable);
            gameObject.GetComponent<Renderer>().material = PressedMat;
        }
    }
}
