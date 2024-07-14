using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OLD_DroneInputController : MonoBehaviour
{
    private OLD_FlightController fc;
    Transform droneTransform;
    void Start()
    {
        fc = GameObject.FindGameObjectWithTag("Drone").GetComponent<OLD_FlightController>();
        droneTransform = GameObject.FindGameObjectWithTag("Drone").GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 transversalMovement = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

        if (Input.GetKey(KeyCode.Space))
            fc.IncreaseRPM();
        if (Input.GetKey(KeyCode.LeftControl))
            fc.DecreaseRPM();

        droneTransform.Translate(transversalMovement * Time.deltaTime);
    }

    private void Awake()
    {
        //fc = GameObject.FindGameObjectWithTag("Drone").GetComponent<FlightController>();
    }
}
