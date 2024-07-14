using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OLD_FlightController : MonoBehaviour
{
    public float RPM = 0f;
    private float f_RPM_Variation_PerSeconde = 750;

    public float Diameter = 0.1f;
    public float mass = 1.3f;
    public float WingSuface = 0.012f;
    private const float AirDensity = 1.293f/2f;
    private const float C_Lift = 0.5f;
    private const float gravity = -9f;

    private GameObject[] helices;
    // Start is called before the first frame update
    void Start()
    {
        helices = GameObject.FindGameObjectsWithTag("Helice");
    }

    // Update is called once per frame
    void Update()
    {

        float Speed = RPM * Mathf.PI * Diameter / 60;
        float Lift = C_Lift * AirDensity * Speed * Speed * WingSuface;

        float velocityY = Lift * 4 * Time.deltaTime + gravity * Time.deltaTime ;

        transform.position += new Vector3(0, velocityY, 0);
            if (transform.position.y < 0) transform.position = new Vector3(transform.position.x, 0, transform.position.z);

        foreach(GameObject helice in helices) {
            float anglePerSecond = RPM * 6 * Time.deltaTime;
            helice.transform.Rotate(0, anglePerSecond, 0, Space.World);
        }

    }

    public void IncreaseRPM()
    {
        RPM += f_RPM_Variation_PerSeconde * Time.deltaTime;
    }
    public void DecreaseRPM()
    {
        RPM -= f_RPM_Variation_PerSeconde * Time.deltaTime;
    }
}
