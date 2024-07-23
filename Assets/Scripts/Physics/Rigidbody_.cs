using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public abstract class Rigidbody_: MonoBehaviour
{
    [Header("Rigidbody properties")]
    [SerializeField] private float weightInKg = 1.0f;

    protected Rigidbody rb;
    protected float startDrag;
    protected float startAngularDrag;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        if (!rb) return;

        rb.mass = weightInKg;
        startDrag = rb.drag;
        startAngularDrag = rb.angularDrag;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!rb) return;

        HandlePhysics();
    }

    protected virtual void HandlePhysics() { }

    public Rigidbody GetRigidbody() { return rb; }
}
