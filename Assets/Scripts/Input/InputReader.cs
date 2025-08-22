using System;
using UnityEngine;
using UnityEngine.InputSystem;
[RequireComponent(typeof(PlayerInput))]
public class InputReader : MonoBehaviour
{
    public static event Action<Vector2> OnMovePlayer;
    public static event Action<Vector2> OnMoveCamera;
    public static event Action<bool> OnJump;
    public void InputMovePlayer(InputAction.CallbackContext context)
    {
        OnMovePlayer?.Invoke(context.ReadValue<Vector2>());
    }
    public void InputMoveCamera(InputAction.CallbackContext context)
    {
        OnMoveCamera?.Invoke(context.ReadValue<Vector2>());
    }
    public void InputJump(InputAction.CallbackContext context)
    {
        OnJump?.Invoke(context.performed);
    }
}
