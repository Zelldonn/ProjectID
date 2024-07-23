using FMOD.Studio;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneSFX : MonoBehaviour
{
    private DroneInputs droneInputs;

    EventInstance soundInstance;

    DroneController droneController;

    float lerpSpeed = 5f;

    void Start()
    {
        droneInputs = GetComponent<DroneInputs>();
        droneController = GetComponent<DroneController>();

        soundInstance = AudioManager.instance.CreateInstance(FmodEvents.instance.Drone);
        soundInstance = AudioManager.instance.AttachInstanceToGameObject(soundInstance, droneController.transform, droneController.GetRigidbody());
        soundInstance.start();
    }

    // Update is called once per frame
    void Update()
    {
        HandleSFX();
    }

    void HandleSFX()
    {
        float targetRPM = 50f + Mathf.Abs(droneInputs.Cyclic.y) * 15f + Mathf.Abs(droneInputs.Cyclic.x) * 15f + Mathf.Abs(droneInputs.Yaw) * 8f + droneInputs.Throtlle * 20f;
        droneController.engineRPM = Mathf.Lerp(targetRPM, droneController.engineRPM, Time.deltaTime * lerpSpeed);

        droneController.engineRPM += Mathf.Sin(Time.time * 2f) * 7f;
        AudioManager.instance.SetInstanceParameterByName(soundInstance, "RPM", droneController.engineRPM);
    }

}
