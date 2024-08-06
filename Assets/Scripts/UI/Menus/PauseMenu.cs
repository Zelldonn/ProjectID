using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] Button Resume;
    [SerializeField] Button Options;
    [SerializeField] Button Menu;
    [SerializeField] Button Quit;

    [SerializeField] PauseManager manager;

    void Start()
    {
        Resume.onClick.AddListener(OnResume);
        Options.onClick.AddListener(OnOption);
        Menu.onClick.AddListener(OnMenu);
        Quit.onClick.AddListener(OnQuit);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnResume()
    {
        manager.ResumeGame();
    }
    private void OnQuit()
    {
        Application.Quit();
    }
    private void OnOption()
    {
        manager.setPauseMenuState(false);  
        manager.setOptionMenuState(true);
    }
    private void OnMenu()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }
}
