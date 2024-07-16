using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpDroneManager : MonoBehaviour
{
    public GameObject Drone;
    private GameObject DroneInstance;

    private ContextManager ContextManager;

    private float maxInteractionRange = 2.5f;

    bool b_IsdroneDropped = false;
    void Start()
    {
        ContextManager = GameObject.Find("Managers").GetComponent<ContextManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.F) && DroneInstance == null)
        {
            if (!IsInteracting())
                DropDrone();
        }
        else if (Input.GetKeyUp(KeyCode.F) && DroneIsInRange())
            PickUpDrone();
    }

    void DropDrone()
    {
        Vector3 spawnPosition = transform.position + transform.forward * maxInteractionRange;
        DroneInstance = Instantiate(Drone, spawnPosition, Quaternion.identity);
        // OPTI : This is not opti as we will try to find go each time
        ContextManager.ForceFindContext(ContextManager.EContext.DroneContext);
        ContextManager.SetContextState(ContextManager.EContext.DroneContext, false);
        b_IsdroneDropped = true;
    }

    void PickUpDrone()
    {
        Destroy(DroneInstance);
        b_IsdroneDropped = false;
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

    public bool IsDroneDropped()
    {
        return b_IsdroneDropped;
    }

    bool IsInteracting()
    {
        RaycastHit hit;
        Interactable interactable;

        if (!Physics.Raycast(transform.position, transform.forward, out hit, 5.0f)) return false;

        interactable = hit.collider.GetComponent<Interactable>();

        if (interactable == null) return false;
        return true;
    }
}
