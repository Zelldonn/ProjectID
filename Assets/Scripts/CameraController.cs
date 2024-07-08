using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;
using static UnityEngine.GraphicsBuffer;

public class CameraController : MonoBehaviour
{
    private GameObject _drone;
    public float CameraDistance = 3f;
    public float _angleRad = 0f, _angleRadY = 0f;
    void Start()
    {
        _drone = GameObject.FindGameObjectWithTag("Drone");

    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(_drone.transform, Vector3.up);

        _angleRad += Input.GetAxis("Mouse X") * Time.deltaTime * 5f;
        _angleRadY += Input.GetAxis("Mouse Y") * Time.deltaTime * 5f;


        float x_new = _drone.transform.localPosition.x + CameraDistance * Mathf.Cos(_angleRad);
        float z_new = _drone.transform.localPosition.z + CameraDistance * Mathf.Sin(_angleRad);
        float y_new = _drone.transform.localPosition.y + CameraDistance * Mathf.Cos(_angleRadY);

        transform.position = new Vector3(x_new, y_new, z_new);
        //transform.RotateAround(_drone.transform.position, Vector3.up, 20 * Time.deltaTime);



    }
}
