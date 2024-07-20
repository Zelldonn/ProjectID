using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarageDoor : MonoBehaviour
{
    Animator doorAnimator;
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
        doorAnimator = GetComponent<Animator>();
        doorMesh = GetComponent<MeshRenderer>();
        collider = GetComponent<BoxCollider>();
        if (doorMesh.enabled)
            state = State.Closed;
        else
            state = State.Openned;
    }

    public void SwitchState()
    {
        AudioManager.instance.PlayOnShot(FmodEvents.instance.garageDoor, this.transform.position);
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
        //doorMesh.enabled = true;
        //collider.enabled = true;
        doorAnimator.ResetTrigger("OpenDoor");
        doorAnimator.SetTrigger("CloseDoor");
    }

    void openDoor()
    {
        state = State.Openned;
        //doorMesh.enabled = false;
        //collider.enabled = false;
        doorAnimator.ResetTrigger("CloseDoor");
        doorAnimator.SetTrigger("OpenDoor");
    }
}
