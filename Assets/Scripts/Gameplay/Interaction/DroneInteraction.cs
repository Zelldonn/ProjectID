using System;
using UnityEngine;
using UnityEngine.InputSystem;

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
            //Vector3 newVector = digicode.transform.position - transform.position;

            //float Angle = Mathf.Abs(Vector3.Angle(newVector, transform.position));
            if (Distance > MaxInteractionDistance) continue;
            //Debug.Log(Angle);

            interactable = digicode.GetComponent<Interactable>();
            interactable.ShowUI();

            bool buttonPressed = Gamepad.current.buttonWest.wasPressedThisFrame;
            if (Input.GetKeyDown(KeyCode.F) || buttonPressed)
            {
                AudioManager.instance.PlayOneShot(FmodEvents.instance.HackInteration, this.transform.position);
                interactable.Interact();
            }
        }
    }

}
