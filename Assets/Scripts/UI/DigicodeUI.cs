using UnityEngine;

public class DigicodeUI : MonoBehaviour
{
    Canvas UICanvas;
    public float keyHintStayDuration = 0.1f;

    private float lastTimeInteraction;
    void Start()
    {
        UICanvas = GetComponent<Canvas>();
        UICanvas.enabled = false;
    }

    void Update()
    {
        if (lastTimeInteraction + keyHintStayDuration > Time.time)
            UICanvas.enabled = false;
    }

    public void setUIVisible(bool state)
    {
        UICanvas.enabled = true;
        lastTimeInteraction = Time.time;
    }
}
