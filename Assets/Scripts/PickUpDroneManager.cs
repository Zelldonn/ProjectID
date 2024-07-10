using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpDroneManager : MonoBehaviour
{
    public GameObject Drone;
    private GameObject DroneInstance;

    private float maxInteractionRange = 2.5f;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.F) && DroneInstance == null)
            DropDrone();
        else if (Input.GetKeyUp(KeyCode.F) && DroneIsInRange())
            PickUpDrone();
    }

    void DropDrone()
    {
        Vector3 spawnPosition = transform.position + transform.forward * maxInteractionRange;
        DroneInstance = Instantiate(Drone, spawnPosition, Quaternion.identity);
    }

    void PickUpDrone()
    {
        Destroy(DroneInstance);
    }

    bool DroneIsInRange()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (!Physics.Raycast(ray, out hit, maxInteractionRange))
            return false;

        if (hit.collider.gameObject.tag == "DroneInteraction")
            return true;

        return false;
    }
}
