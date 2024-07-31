using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Button Play;
    [SerializeField] Button Options;
    [SerializeField] Button Quit;
    
    Canvas canvas;
    void Start()
    {
        canvas = GetComponent<Canvas>();    

        Play.onClick.AddListener(OnPlay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnPlay()
    {
        SceneManager.LoadScene("Drone", LoadSceneMode.Single);
    }
}
 