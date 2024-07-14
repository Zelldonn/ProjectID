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

    private OLD_DroneInputController input;
    private List<IEngine> engines = new List<IEngine>();
    void Start()
    {
        input = GetComponent<OLD_DroneInputController>();
        engines = GetComponentsInParent<IEngine>().ToList();
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
            engine.UpdateEngine();
        }
        //rb.AddForce(Vector3.up * rb.mass * (Physics.gravity.magnitude + Mathf.Sin(Time.time) * 0.1f));
    }
    protected virtual void HandleControls() { }
}
