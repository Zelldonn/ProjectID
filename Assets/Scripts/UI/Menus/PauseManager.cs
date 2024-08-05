using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : UIManager
{
    bool isPaused = false;
    void Start()
    {
        
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){
            if (getOptionMenuState() == true)
            {
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
