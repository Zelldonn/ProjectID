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
        bool startPressed = false;
        bool BPressed = false;
        if (Gamepad.current != null)
        {
            startPressed = Gamepad.current.startButton.wasPressedThisFrame;
            BPressed = Gamepad.current.buttonEast.wasPressedThisFrame;
        }

        if(startPressed)
        {
            if (isPaused)
            {
                ForceResumeGame();
            }
            else
            {
                PauseGame();
            }
        }


        if (Input.GetKeyDown(KeyCode.Escape) || BPressed)
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                if (BPressed)
                    return;
                PauseGame();
            }
        }

    }

    public void PauseGame()
    {
        Cursor.visible = true;
        setPauseMenuState(true);
        setOptionMenuState(false);
        Time.timeScale = 0;
        isPaused = true;
    }

    public void ResumeGame()
    {
        if(getOptionMenuState() == true)
        {
            CloseOption();
            return;
        }
        setPauseMenuState(false);
        setOptionMenuState(false);
        Time.timeScale = 1;
        isPaused = false;

        Cursor.visible = false;
    }

    public void ForceResumeGame()
    {
        setPauseMenuState(false);
        setOptionMenuState(false);
        Time.timeScale = 1;
        isPaused = false;

        Cursor.visible = false;
    }

    public void CloseOption()
    {
        setOptionMenuState(false);
        setPauseMenuState(true);
    }
}
