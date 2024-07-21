
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

        Vector3 vectUp = transform.up;
        vectUp.x = 0f;
        vectUp.z = 0f;
        float diff = 1 - vectUp.magnitude;
        float finalDiff = Physics.gravity.magnitude * diff ;
        Vector3 engineForce = transform.up * ((rb.mass * Physics.gravity.magnitude + finalDiff) + (maxPower * inputs.Throtlle)) / 4f;
        rb.AddForce(engineForce, ForceMode.Force);
    }

}
