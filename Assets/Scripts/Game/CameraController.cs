using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Camera Settings")]
    public float sensitivity = 2f;

    private float rotationX = 0f;
    private Transform playerBody;


    private void OnEnable()
    {
        PlayerController.OnGetCamera += GetCamera;
        InputReader.OnMoveCamera += RotateCamera;
    }

    private void OnDisable()
    {
        PlayerController.OnGetCamera -= GetCamera;
        InputReader.OnMoveCamera -= RotateCamera;
    }

    private void Start()
    {
        playerBody = transform.parent;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private Transform GetCamera()
    {
        return transform;
    }
    private void RotateCamera(Vector2 value)
    {
        float mouseX = value.x * sensitivity * Time.deltaTime;
        float mouseY = value.y * sensitivity * Time.deltaTime;

        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f);

        transform.localRotation = Quaternion.Euler(rotationX, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }

}