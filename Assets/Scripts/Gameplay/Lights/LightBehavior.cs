using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBehavior : MonoBehaviour
{
    public float blinkRate = 1f;

    float lastTime = 0f;
    Light light;
    void Start()
    {
        light = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateLight();
    }

    private void UpdateLight()
    {
        if(Time.time > lastTime + blinkRate)
        {
            light.enabled = !light.enabled;
            lastTime = Time.time;
        }
    }
}
