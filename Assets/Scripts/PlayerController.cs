using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class PlayerController : MonoBehaviour
{
    public float sensitivity = 100f;

    public float walkSpeed = 2.4f;
    public float runSpeed = 5.5f;
    public float speedSmoothTime = 0.2f;
    Vector3 targetAngles;

    float currentSpeed;
    float speedSmoothVelocity;

    Transform cameraTransform;
    CharacterController controller;
    void Start()
    {
        cameraTransform = GetComponentInChildren<Camera>().transform;
        controller = GetComponentInChildren<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 keyboardRawInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        Vector2 keyboardDir = keyboardRawInput;
        keyboardDir.Normalize();

        bool runningDiagLeft = keyboardRawInput == new Vector2(-1, 1);
        bool runningDiagRight = keyboardRawInput == new Vector2(1, 1);
        bool runningStraight = keyboardRawInput == new Vector2(0, 1);

        bool running = Input.GetKey(KeyCode.LeftShift) && (runningStraight || runningDiagLeft || runningDiagRight);
        float targetSpeed = ((running) ? runSpeed : walkSpeed) * keyboardDir.magnitude;

        currentSpeed = Mathf.SmoothDamp(currentSpeed, targetSpeed, ref speedSmoothVelocity, speedSmoothTime);

        Vector3 finalDirection = (keyboardDir.x * cameraTransform.right + keyboardDir.y * transform.forward) * currentSpeed;

        controller.Move(finalDirection * Time.deltaTime);
    }

    private void LateUpdate()
    {
        Vector2 mouseDir = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        transform.eulerAngles += Vector3.up * mouseDir.x * sensitivity * Time.deltaTime;


        targetAngles.x = Mathf.Clamp(targetAngles.x - mouseDir.y * sensitivity * Time.deltaTime, -70, 80);
        cameraTransform.localEulerAngles = targetAngles;

    }
}
