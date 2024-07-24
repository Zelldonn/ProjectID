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

    Animator doorAnimator;
    State state;

    void Start()
    {
        doorAnimator = GetComponent<Animator>();
    }

    public void SwitchState()
    {
        if (state == State.Openning || state == State.Closing) return;

        AudioManager.instance.PlayOneShot(FmodEvents.instance.garageDoor, this.transform.position);
        if (state == State.Openned)
        {
            closeDoor();
        }
        else
        {
            openDoor();
        }
    }

    public void OnClosed()
    {
        state = State.Closed;
    }
    public void OnOpenned()
    {
        state = State.Openned;
    }

    void closeDoor()
    {
        state = State.Closing;
        doorAnimator.ResetTrigger("OpenDoor");
        doorAnimator.SetTrigger("CloseDoor");
    }

    void openDoor()
    {
        state = State.Openning;
        doorAnimator.ResetTrigger("CloseDoor");
        doorAnimator.SetTrigger("OpenDoor");
    }
}
