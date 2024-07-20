
using UnityEngine;
[RequireComponent (typeof(BoxCollider))]
public class DroneEngine : MonoBehaviour, IEngine
{

    [SerializeField] private float maxPower = 8f;
    void Start() 
    {
        
    }

    void Update()
    {
        
    }

    public void InitEngine()
    {
        throw new System.NotImplementedException();
    }

    public void UpdateEngine(Rigidbody rb, DroneInputs inputs)
    {
 
        Vector3 engineForce = transform.up * ((rb.mass * Physics.gravity.magnitude) + (maxPower * inputs.Throtlle)) / 4f;
        rb.AddForce(engineForce, ForceMode.Force);
    }

}
