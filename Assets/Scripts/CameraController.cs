using UnityEngine;


public class CameraController : MonoBehaviour
{
    private GameObject _drone;
    private float CameraDistance = 3f, TargetCameraDistance = 3f;
    private float _Theta = 0.9834613f, _Phi = 4.5f;
   
    void Start()
    {
        _drone = GameObject.FindGameObjectWithTag("Drone");

        UpdateCamera();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        UpdateCameraPosition();
        UpdateCameraDistance();
        UpdateCamera();
    }

    private void UpdateCameraPosition()
    {
        if (_drone == null) return;
        if (Input.GetAxis("Fire2") != 0)
        {
            _Phi += Input.GetAxis("Mouse X") * Time.deltaTime * 5f;
            _Theta -= Input.GetAxis("Mouse Y") * Time.deltaTime * 5f;

            const float epsylon = 0.5f;
            if(_Theta > Mathf.PI - epsylon) _Theta = Mathf.PI - epsylon;
            if (_Theta < 0f + epsylon) _Theta = 0f + epsylon;

            //if (_Phi > Mathf.PI * 2) _Phi = Mathf.PI * 2;
            //if (_Phi < 0f) _Phi = 0f;

        }
    }


    private void UpdateCamera()
    {
        if (_drone == null) return;
        
        float x = CameraDistance * Mathf.Sin(_Theta) * Mathf.Cos(_Phi);
        float y = CameraDistance * Mathf.Sin(_Theta) * Mathf.Sin(_Phi);
        float z = CameraDistance * Mathf.Cos(_Theta);

        Vector3 targetPosition = new Vector3(x, z, y) + _drone.transform.position;
        transform.position = Vector3.Lerp(transform.position, targetPosition, .6f);

        Vector3 targetCameraPosition = _drone.transform.position;
        Vector3 newPos = Vector3.Lerp(_drone.transform.position, targetCameraPosition, .6f);

        //transform.LookAt(_drone.transform, Vector3.up);
        transform.LookAt(newPos, Vector3.up);
    }
    private void UpdateCameraDistance()
    {
        if (_drone == null) return;

        if (Input.GetAxis("Mouse ScrollWheel") != 0)
            TargetCameraDistance = CameraDistance - Input.GetAxis("Mouse ScrollWheel") * 5f;

        if (Input.GetAxis("Mouse ScrollWheel") == 0)
            CameraDistance = Mathf.Lerp(CameraDistance, TargetCameraDistance, .1f);

    }
}
