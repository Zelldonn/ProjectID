using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class InteractionInputs : MonoBehaviour
{
    private bool Interact; 

    private void OnInteract(InputValue inputValue)
    {
        //Interact = inputValue.Get());
    }
}
