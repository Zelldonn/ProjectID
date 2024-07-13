using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarageDoor : MonoBehaviour
{
    public enum State
    {
        Closed,
        Openned,
        Closing,
        Openning,
    }

    State state;

    MeshRenderer doorMesh;
    private new BoxCollider collider;

    void Start()
    {
        doorMesh = GetComponent<MeshRenderer>();
        collider = GetComponent<BoxCollider>();
    }

    public void SwitchState()
    {
        if (state == State.Openned)
        {
            closeDoor();
        }
        else
        {
            openDoor();
        }
    }

    void closeDoor()
    {
        state = State.Closed;
        doorMesh.enabled = true;
        collider.enabled = true;
    }

    void openDoor()
    {
        state = State.Openned;
        doorMesh.enabled = false;
        collider.enabled = false;
    }
}
