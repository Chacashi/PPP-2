using System;
using UnityEngine;
using UnityEngine.InputSystem;
[RequireComponent(typeof(PlayerInput))]
public class InputReader : MonoBehaviour
{
    public static event Action<Vector2> OnMovePlayer;
    public static event Action<Vector2> OnMoveCamera;
    public void InputMovePlayer(InputAction.CallbackContext context)
    {
        OnMovePlayer?.Invoke(context.ReadValue<Vector2>());
    }
    public void InputMoveCamera(InputAction.CallbackContext context)
    {
        OnMoveCamera?.Invoke(context.ReadValue<Vector2>());
    }
}
