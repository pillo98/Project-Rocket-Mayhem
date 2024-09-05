using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    [SerializeField]
    private GameObject PauseMenu;
    [SerializeField]
    private StarterAssetsInputs playerInput;
    private CharacterController characterController;
    public bool GamePaused = false;

    private void Awake()
    {
        characterController = playerInput.gameObject.GetComponent<CharacterController>();
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
            pauseGame();
        }
        else if(Input.GetKey(KeyCode.Escape) && GamePaused == true)
        {
            resumeGame();
        }
         


    }

    public void pauseGame()
    {
        PauseMenu.SetActive(true);
        playerInput.cursorLocked = false;
        playerInput.cursorInputForLook = false;
        Time.timeScale = 0;
        GamePaused = true;
        
    }

    public void resumeGame() 
    {
        PauseMenu.SetActive(false);
        playerInput.cursorLocked = true;
        playerInput.cursorInputForLook = true;
        Time.timeScale = 1;
        GamePaused = false;
    }
}
