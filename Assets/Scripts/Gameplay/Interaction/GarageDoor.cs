using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
public class GarageDoor : MonoBehaviour
{
    [SerializeField] private EventReference _doorEventSound;
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
        AudioManager.instance.PlayOnShot(_doorEventSound, this.transform.position);
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
        doorAnimator.ResetTrigger("TriggerDoor");
        doorAnimator.SetTrigger("TriggerDoor");
    }

    void openDoor()
    {
        state = State.Openned;
        //doorMesh.enabled = false;
        //collider.enabled = false;
        doorAnimator.ResetTrigger("TriggerDoor");
        doorAnimator.SetTrigger("TriggerDoor");
    }
}
