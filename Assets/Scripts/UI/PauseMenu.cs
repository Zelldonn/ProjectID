using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] Slider SoundAll;
    [SerializeField] Button Back;

    [SerializeField] UIManager manager;
    void Start()
    {
        SoundAll.onValueChanged.AddListener(OnChange);
        Back.onClick.AddListener(OnBack);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnChange(float value)
    {
        Debug.Log(value);
    }
    void OnBack()
    {
        manager.setmainMenuState(true);
        manager.setPauseMenuState(false);
    }
}
