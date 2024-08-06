using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class OptionMenu : MonoBehaviour
{
    [field: Header("General")]
    [SerializeField] Button Back;

    [field: Header("Sound")]
    [SerializeField] Slider SoundAll;

    [field: Header("Camera")]
    [SerializeField] Slider MouseSensi;
    [SerializeField] Slider ControllerSensi;


    [SerializeField] PauseManager manager;
    [SerializeField] UIManager UImanager;
    void Start()
    {
        SoundAll.onValueChanged.AddListener(OnChange);

        MouseSensi.onValueChanged.AddListener(OnMouseChange);
        ControllerSensi.onValueChanged.AddListener(OnControllerChange);

        Back.onClick.AddListener(OnBack);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnChange(float value)
    {
        FmodVCA.instance.MasterVCA.setVolume(value);

        value = Mathf.Round((value * 100));
        SoundAll.GetComponentInChildren<TMP_Text>().text = value.ToString() + "%";
    }

    void OnMouseChange(float value)
    {
        value = Mathf.Round((value * 100));
        CameraController.instance.SetMouseSensitivity(value);
        MouseSensi.GetComponentInChildren<TMP_Text>().text = value.ToString() + "%";
    }
    void OnControllerChange(float value)
    {
        value = Mathf.Round((value * 100));
        CameraController.instance.SetControllerSensitivity(value);
        ControllerSensi.GetComponentInChildren<TMP_Text>().text = value.ToString() + "%";
    }
    void OnBack()
    {
        if(SceneManager.GetActiveScene().name == "MainMenu")
        {

            UImanager.setOptionMenuState(false);
            UImanager.setmainMenuState(true);
            return;
        }
        manager.setOptionMenuState(false);
        manager.setPauseMenuState(true);
    }



}

