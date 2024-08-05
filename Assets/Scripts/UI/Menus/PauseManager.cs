using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseManager : UIManager
{
    bool isPaused = false;
    void Start()
    {
        
    }
    
    void Update()
    {
        bool buttonPressed = false;
        bool BPressed = false;
        if (Gamepad.current != null)
        {
            buttonPressed = Gamepad.current.startButton.wasPressedThisFrame;
            BPressed = Gamepad.current.buttonEast.wasPressedThisFrame;
        }
            
        if (Input.GetKeyDown(KeyCode.Escape) || buttonPressed || BPressed)
        {
            if (getOptionMenuState() == true)
            {
                if(buttonPressed)
                {
                    setOptionMenuState(false);
                    ResumeGame();
                    return;
                }
                setOptionMenuState(false);
                setPauseMenuState(true);
                return;
            }

            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
            
        }
    }

    public void PauseGame()
    {
        Cursor.visible = true;
        setPauseMenuState(true);
        Time.timeScale = 0;
        isPaused = true;
    }

    public void ResumeGame()
    {
        setPauseMenuState(false);
        Time.timeScale = 1;
        isPaused = false;

        Cursor.visible = false;

    }
}
