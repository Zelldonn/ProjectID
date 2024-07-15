using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class DroneInputs : MonoBehaviour
{
    private Vector2 cyclic;
    private float yaw;
    private float throtlle;

    public Vector2 Cyclic { get => cyclic; }
    public float Yaw { get => yaw; }
    public float Throtlle { get => throtlle; }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCyclic(InputValue inputValue)
    {
        cyclic = inputValue.Get<Vector2>();
    }
    private void OnYaw(InputValue inputValue)
    {
        yaw = inputValue.Get<float>();
    }
    private void OnThrottle(InputValue inputValue)
    {
        throtlle = inputValue.Get<float>();
    }
}
