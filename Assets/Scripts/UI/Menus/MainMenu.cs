using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Button Play;
    [SerializeField] Button Options;
    [SerializeField] Button Quit;

    [SerializeField] UIManager manager;
    
    void Start()
    {
        Play.onClick.AddListener(OnPlay);
        Options.onClick.AddListener(OnOption);
        Quit.onClick.AddListener(OnQuit);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnPlay()
    {
        SceneManager.LoadScene("Drone", LoadSceneMode.Single);
    }
    private void OnQuit()
    {
        Application.Quit();
    }
    private void OnOption()
    {
        manager.setPauseMenuState(true);
        manager.setmainMenuState(false);
    }
}
 