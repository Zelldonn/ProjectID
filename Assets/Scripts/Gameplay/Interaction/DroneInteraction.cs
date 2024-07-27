using System;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.GraphicsBuffer;

public class DroneInteraction : MonoBehaviour
{
    GameObject[] digicodes;
    public float MaxInteractionDistance = 3f;
    Interactable interactable;

    private void Start()
    {
        digicodes = GameObject.FindGameObjectsWithTag("Interactable");
    }
    private void Update()
    {
        foreach(GameObject digicode in digicodes)
        {
            
            float Distance = Mathf.Abs(Vector3.Distance(digicode.transform.position, transform.position));

            if (Distance > MaxInteractionDistance) continue;

            if (Physics.Linecast(transform.position, digicode.transform.position))
            {
                continue;
            }
                

            interactable = digicode.GetComponent<Interactable>();
            interactable.ShowUI();

            bool buttonPressed = false;
            if (Gamepad.current != null)
                buttonPressed = Gamepad.current.buttonWest.wasPressedThisFrame;
            if (Input.GetKeyDown(KeyCode.F) || buttonPressed)
            {
                AudioManager.instance.PlayOneShot(FmodEvents.instance.HackInteration, this.transform.position);
                interactable.Interact();
            }
        }
    }

}
