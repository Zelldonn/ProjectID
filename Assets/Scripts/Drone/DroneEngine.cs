
using UnityEngine;
[RequireComponent (typeof(BoxCollider))]
public class DroneEngine : MonoBehaviour, IEngine
{

    [SerializeField] private float maxPower = 4f;
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

    public void UpdateEngine()
    {
        throw new System.NotImplementedException();
    }

}
