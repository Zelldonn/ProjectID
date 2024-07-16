using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class FPVInputs : MonoBehaviour
{
    private Vector2 moveDirection;
    private Vector2 lookDirection;

    public Vector2 GetMoveDirection { get => moveDirection; }
    public Vector2 GetLookDirection { get => lookDirection; }


    private void OnMove(InputValue inputValue)
    {
        moveDirection = inputValue.Get<Vector2>();
    }

    private void OnLook(InputValue inputValue)
    {
        lookDirection = inputValue.Get<Vector2>();
    }

}
