using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;
using static UnityEngine.GraphicsBuffer;

public class CameraController : MonoBehaviour
{
    private GameObject _drone;
    public float CameraDistance = 3f;
    public float _Theta = 0f, _Phi = 0f;
    void Start()
    {
        _drone = GameObject.FindGameObjectWithTag("Drone");

    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(_drone.transform, Vector3.up);

        _Phi += Input.GetAxis("Mouse X") * Time.deltaTime * 5f;
        _Theta -= Input.GetAxis("Mouse Y") * Time.deltaTime * 5f;

        _Phi += Input.GetAxis("VerticalG") * Time.deltaTime * 5f;
        _Theta -= Input.GetAxis("HorizontalG") * Time.deltaTime * 5f;

        float x = CameraDistance * Mathf.Sin(_Theta) * Mathf.Cos(_Phi);
        float y = CameraDistance * Mathf.Sin(_Theta) * Mathf.Sin(_Phi);
        float z = CameraDistance * Mathf.Cos(_Theta);

        transform.position = new Vector3(x, z, y) + _drone.transform.position;
    }
}
