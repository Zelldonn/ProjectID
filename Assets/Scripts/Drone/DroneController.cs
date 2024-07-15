using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

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
        //rb.AddForce(Vector3.up * rb.mass * (Physics.gravity.magnitude + Mathf.Sin(Time.time) * 0.1f));
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
        //Quaternion rot = Quaternion.Slerp(rb.rotation, targetRotation, Time.deltaTime * lerpSpeed);
        rb.MoveRotation(targetRotation);
    }
}
