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
    private float rollYawFactor = -1f;

    private float lerpSpeed = 5f;
    private float yaw;
    private float targetPitch;
    private float targetRoll;
    private float targetYaw;

    private DroneInputs droneInputs;
    private List<IEngine> engines = new List<IEngine>();

    public float engineRPM = 50f;


    void Start()
    {
        droneInputs = GetComponent<DroneInputs>();
        engines = GetComponentsInChildren<IEngine>().ToList();
    }
    protected override void HandlePhysics()
    {
        HandleEngines();
        HandleControls();
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
        // TODO : Refactor this function
        float pitch;
        if (droneInputs.Throtlle != 0)
            pitch = droneInputs.Cyclic.y * minMaxPitch + Mathf.Abs(droneInputs.Throtlle) * 30 * droneInputs.Cyclic.y;
        else
            pitch = droneInputs.Cyclic.y * minMaxPitch;

        float roll = droneInputs.Cyclic.x * minMaxRoll;

        float PitchFactor= 0f;
        float yawOverride = droneInputs.Cyclic.x;
        if (droneInputs.Cyclic.y == 0)
            PitchFactor = 0.6f;
        else
            PitchFactor = droneInputs.Cyclic.y;

        float reverseThreshold = -0.8f;

        

        if (droneInputs.Cyclic.y == 0)
            PitchFactor = 1f;
        else
        {
            if (droneInputs.Cyclic.y < reverseThreshold)
            {
                PitchFactor = droneInputs.Cyclic.y;
            }
            else
                PitchFactor = Mathf.Abs(droneInputs.Cyclic.y);
        }

        yaw += droneInputs.Yaw * yawPower + yawOverride * rollYawFactor * (1+PitchFactor);
        //else
        // yaw += droneInputs.Yaw * yawPower;


        targetPitch = Mathf.Lerp(targetPitch, pitch, Time.fixedDeltaTime * lerpSpeed);
        targetRoll = Mathf.Lerp(targetRoll, roll, Time.fixedDeltaTime * lerpSpeed);
        targetYaw = Mathf.Lerp(targetYaw, yaw, Time.fixedDeltaTime * lerpSpeed);

        

        Quaternion targetRotation = Quaternion.Euler(targetPitch, targetYaw, targetRoll);
        rb.MoveRotation(targetRotation);


        //rb.AddTorque(new Vector3(pitch, droneInputs.Yaw, roll) * Time.fixedDeltaTime);
    }
}
