using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class OptionMenu : MonoBehaviour
{
    [SerializeField] Slider SoundAll;
    [SerializeField] Button Back;

    [SerializeField] PauseManager manager;
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

        UpdateUI(value);
    }
    void OnBack()
    {
        manager.setOptionMenuState(false);
        manager.setPauseMenuState(true);
    }


    void UpdateUI(float value)
    {
        value = Mathf.Round((value * 100));
        SoundAll.GetComponentInChildren<TMP_Text>().text = value.ToString() + "%";
    }
}

