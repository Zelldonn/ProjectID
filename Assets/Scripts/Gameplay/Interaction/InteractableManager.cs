using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public float InteractionDistance = 2.0f;
    public abstract void Interact();
    public abstract void ShowUI();

    public float GetInteractionDistance()
    {
        return InteractionDistance;
    }
}
