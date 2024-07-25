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

    Animator animator;

    [Header("Door state")]
    public State state;

    void Start()
    {
        animator = GetComponent<Animator>();

        // Set initial state based on the isOpenAtStart variable
        if (state == State.Openned)
        {
            PlayAnimation("GarageDoorOpenning", 1.0f);
        }
        else
        {
            PlayAnimation("GarageDoorClosing", 1.0f);
        }
    }

    private void PlayAnimation(string stateName, float normalizedTime)
    {
        animator.Play(stateName, 0, normalizedTime);
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
        animator.ResetTrigger("OpenDoor");
        animator.SetTrigger("CloseDoor");
    }

    void openDoor()
    {
        state = State.Openning;
        animator.ResetTrigger("CloseDoor");
        animator.SetTrigger("OpenDoor");
    }
}
