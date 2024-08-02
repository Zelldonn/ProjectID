using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] PauseMenu pauseMenu;
    [SerializeField] MainMenu mainMenu;
    public static UIManager instance { get; private set; }
    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one UI Manager in the scene.");
        }
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void setPauseMenuState(bool state)
    {
        pauseMenu.GetComponent<Canvas>().enabled = state;
    }

    public void setmainMenuState(bool state)
    {
        mainMenu.GetComponent<Canvas>().enabled = state;
    }
}
