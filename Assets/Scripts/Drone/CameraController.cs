using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;


[RequireComponent(typeof(PlayerInput))]
public class CameraController : MonoBehaviour
{
    //private GameObject _drone;
    private float CameraDistance = 3f, TargetCameraDistance = 3f, maxCameraDistance = 10f;
    public float _Theta = 0.9834613f, _Phi = 4.5f;

    private float defaultTheta = 1.3f, defaultPhi = 4.7f;

    public float offset = 0.1f;

    public Transform target;

    public float controllerSensitivity = 2f;

    int layerMask = ~(1 << 2);
    void Start()
    {
        //_drone = GameObject.FindGameObjectWithTag("Drone");

        UpdateCamera();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        UpdateCameraPosition();
        UpdateCameraDistance();
        UpdateCamera();
    }

    private void UpdateCameraPosition()
    {
        if (target == null) return;
        if (Input.GetAxis("Fire2") != 0)
        {
            _Phi += Input.GetAxis("Mouse X") * Time.deltaTime * 5f;
            _Theta -= Input.GetAxis("Mouse Y") * Time.deltaTime * 5f;

            const float epsylon = 0.5f;
            if(_Theta > Mathf.PI - epsylon) _Theta = Mathf.PI - epsylon;
            if (_Theta < 0f + epsylon) _Theta = 0f + epsylon;
        }
    }


    private void UpdateCamera()
    {
        if (target == null) return;

        offset = Mathf.Deg2Rad * target.rotation.eulerAngles.y;
        if (CheckCameraReset())
        {
            _Phi = defaultPhi;
            _Theta = defaultTheta;
        }
        float x = CameraDistance * Mathf.Sin(_Theta) * Mathf.Cos(_Phi - offset);
        float y = CameraDistance * Mathf.Sin(_Theta) * Mathf.Sin(_Phi - offset);
        float z = CameraDistance * Mathf.Cos(_Theta);

        Vector3 targetRotation = new Vector3(x, z, y) + target.position;
        transform.position = Vector3.Lerp(transform.position, targetRotation, .6f);

        
        CameraClip();

        Vector3 targetCameraPosition = target.transform.position;
        Vector3 newPos = Vector3.Lerp(target.transform.position, targetCameraPosition, .6f);

        transform.LookAt(newPos, Vector3.up);
    }
    private void UpdateCameraDistance()
    {
        if (target == null) return;

        if (Input.GetAxis("Mouse ScrollWheel") != 0)
            TargetCameraDistance = CameraDistance - Input.GetAxis("Mouse ScrollWheel") * 5f;

        if (Input.GetAxis("Mouse ScrollWheel") == 0)
            CameraDistance = Mathf.Lerp(CameraDistance, TargetCameraDistance, .1f);

    }

    private void OnDroneCamera(InputValue inputValue)
    {
        Vector2 stick = inputValue.Get<Vector2>();
        _Phi += stick.x * Time.deltaTime * controllerSensitivity;
        _Theta -= stick.y * Time.deltaTime * controllerSensitivity;

        const float epsylon = 0.5f;
        if (_Theta > Mathf.PI - epsylon) _Theta = Mathf.PI - epsylon;
        if (_Theta < 0f + epsylon) _Theta = 0f + epsylon;
    }

    private void CameraClip()
    {

        Vector3 direction = this.transform.position - target.position;
        Ray ray = new Ray(target.position, direction);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, CameraDistance, layerMask)) 
        {
            transform.position = hit.point;
        }
        
    }

    private bool CheckCameraReset()
    {
        if (Gamepad.current != null)
            return Gamepad.current.rightStickButton.wasPressedThisFrame;
        
        return false;
    }

}
