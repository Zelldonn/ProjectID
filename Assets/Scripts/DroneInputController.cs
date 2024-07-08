using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneInputController : MonoBehaviour
{
    private FlightController fc;
    void Start()
    {
        fc = GameObject.FindGameObjectWithTag("Drone").GetComponent<FlightController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 transversalMovement = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

        if (Input.GetKey(KeyCode.Space))
            fc.IncreaseRPM();
        if (Input.GetKey(KeyCode.LeftControl))
            fc.DecreaseRPM();

        transform.Translate(transversalMovement * Time.deltaTime);
    }
}
