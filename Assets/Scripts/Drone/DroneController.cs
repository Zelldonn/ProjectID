using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using FMOD.Studio;

public class DroneController : Rigidbody_
{
    [Header("Controls properties")]
    [SerializeField] private float minMaxPitch = 30f;
    [SerializeField] private float minMaxRoll = 30f;
    [SerializeField] private float yawPower = 4f;

    private float lerpSpeed = 5f;
    private float yaw;
    private float targetPitch;
    private float targetRoll;
    private float targetYaw;

    private DroneInputs droneInputs;
    private List<IEngine> engines = new List<IEngine>();

    public float engineRPM = 50f;

    EventInstance soundInstance;

    void Start()
    {
        droneInputs = GetComponent<DroneInputs>();
        engines = GetComponentsInChildren<IEngine>().ToList();

        soundInstance = AudioManager.instance.CreateInstance(FmodEvents.instance.Drone);
        soundInstance = AudioManager.instance.AttachInstanceToGameObject(soundInstance, this.transform, this.rb);
        soundInstance.start();
    }
    protected override void HandlePhysics()
    {
        HandleEngines();
        HandleControls();
        HandleSFX();
    }

    void HandleSFX()
    {
        float targetRPM = 50f + Mathf.Abs(droneInputs.Cyclic.y) * 15f + Mathf.Abs(droneInputs.Cyclic.x) * 15f + Mathf.Abs(droneInputs.Yaw) * 8f + droneInputs.Throtlle * 20f;
        engineRPM = Mathf.Lerp(targetRPM, engineRPM, Time.deltaTime * lerpSpeed);

        engineRPM += Mathf.Sin(Time.time * 2f) * 7f;
        AudioManager.instance.SetInstanceParameterByName(soundInstance, "RPM", engineRPM);
    }

    protected virtual void HandleEngines() 
    {
        
        
        foreach (IEngine engine in engines) 
        {
            engine.UpdateEngine(rb, droneInputs);
        }
    }
    protected virtual void HandleControls() 
    {

        float pitch = droneInputs.Cyclic.y * minMaxPitch;
        float roll = droneInputs.Cyclic.x * minMaxRoll;
        yaw += droneInputs.Yaw * yawPower;

        targetPitch = Mathf.Lerp(targetPitch, pitch, Time.deltaTime * lerpSpeed);
        targetRoll = Mathf.Lerp(targetRoll, roll, Time.deltaTime * lerpSpeed);
        targetYaw = Mathf.Lerp(targetYaw, yaw, Time.deltaTime * lerpSpeed);

        

        Quaternion targetRotation = Quaternion.Euler(targetPitch, targetYaw, targetRoll);

        rb.MoveRotation(targetRotation);
    }
}
