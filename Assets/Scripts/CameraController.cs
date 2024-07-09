using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;
using static UnityEngine.GraphicsBuffer;

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
        if (Input.GetAxis("Fire2") != 0)
        {
            _Phi += Input.GetAxis("Mouse X") * Time.deltaTime * 5f;
            _Theta -= Input.GetAxis("Mouse Y") * Time.deltaTime * 5f;
        }
    }


    private void UpdateCamera()
    {
        transform.LookAt(_drone.transform, Vector3.up);

        float x = CameraDistance * Mathf.Sin(_Theta) * Mathf.Cos(_Phi);
        float y = CameraDistance * Mathf.Sin(_Theta) * Mathf.Sin(_Phi);
        float z = CameraDistance * Mathf.Cos(_Theta);

        Vector3 targetPosition = new Vector3(x, z, y) + _drone.transform.position;
        transform.position = Vector3.Lerp(transform.position, targetPosition, .6f);
    }
    private void UpdateCameraDistance()
    {
        if (Input.GetAxis("Mouse ScrollWheel") != 0)
            TargetCameraDistance = CameraDistance - Input.GetAxis("Mouse ScrollWheel") * 5f;

        if (Input.GetAxis("Mouse ScrollWheel") == 0)
            CameraDistance = Mathf.Lerp(CameraDistance, TargetCameraDistance, .1f);

        
    }
}
