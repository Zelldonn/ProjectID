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

    void Start()
    {
        doorMesh = GetComponent<MeshRenderer>();
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
    }

    void openDoor()
    {
        state = State.Openned;
        doorMesh.enabled = false;
    }
}
