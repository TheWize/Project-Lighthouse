using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public Transform playerBody;
    public Transform _camera;
    [SerializeField] private float _mouseSensitivity;
    private float _xRotation = 0f;
    private float mouseX;
    private float mouseY;
    [SerializeField] private float mouseSmooth = 0.95f; //Default: 0.95f

    void Start()
    {
        //Reset Cursor position
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        //Mouse look inputs
        mouseX += Input.GetAxis("Mouse X") * _mouseSensitivity * Time.deltaTime;
        mouseY += Input.GetAxis("Mouse Y") * _mouseSensitivity * Time.deltaTime;

        _xRotation -= mouseY;
        _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);
    }

    private void LateUpdate()
    {
        playerBody.Rotate(Vector3.up * mouseX);
        _camera.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
        mouseX *= mouseSmooth;
        mouseY *= mouseSmooth;
    }
}
