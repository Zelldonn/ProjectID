using System;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public float InteractionDistance = 5.0f;
    private void Update()
    {
        RaycastHit hit;
        Interactable interactable;

        if (!Physics.Raycast(transform.position, transform.forward, out hit, InteractionDistance)) return;

        interactable = hit.collider.GetComponent<Interactable>();

        if (interactable == null) return;
        if(interactable.GetInteractionDistance() < hit.distance) return;

        interactable.ShowUI();

        if (Input.GetKeyDown(KeyCode.F))
        {
            interactable.Interact();
        }
    }

}
