using UnityEngine;


[RequireComponent(typeof(FPVInputs))]
public class FPVController : MonoBehaviour
{
    public float sensitivity = 100f;

    public float walkSpeed = 2.4f;
    public float runSpeed = 5.5f;
    public float speedSmoothTime = 0.2f;
    Vector3 targetAngles;

    float currentSpeed;
    float speedSmoothVelocity;

    public Transform cameraTransform, playerTransform;
    CharacterController characterController;
    private FPVInputs fpvInputs;
    void Start()
    {
        fpvInputs = GetComponent<FPVInputs>();
        characterController = GetComponentInParent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 keyboardRawInput = fpvInputs.GetMoveDirection;
        Vector2 keyboardDir = keyboardRawInput;
        //keyboardDir.Normalize();

        bool runningDiagLeft = keyboardRawInput == new Vector2(-1, 1);
        bool runningDiagRight = keyboardRawInput == new Vector2(1, 1);
        bool runningStraight = keyboardRawInput == new Vector2(0, 1);

        bool running = Input.GetKey(KeyCode.LeftShift) && (runningStraight || runningDiagLeft || runningDiagRight);
        float targetSpeed = ((running) ? runSpeed : walkSpeed) * keyboardDir.magnitude;

        currentSpeed = Mathf.SmoothDamp(currentSpeed, targetSpeed, ref speedSmoothVelocity, speedSmoothTime);

        Vector3 finalDirection = (keyboardDir.x * cameraTransform.right + keyboardDir.y * playerTransform.forward) * currentSpeed;

        characterController.Move(finalDirection * Time.deltaTime);
    }

    private void LateUpdate()
    {
        Vector2 lookDir = fpvInputs.GetLookDirection;
        playerTransform.eulerAngles += Vector3.up * lookDir.x * sensitivity * Time.deltaTime;


        targetAngles.x = Mathf.Clamp(targetAngles.x - lookDir.y * sensitivity * Time.deltaTime, -70, 80);
        cameraTransform.localEulerAngles = targetAngles;

    }
}
