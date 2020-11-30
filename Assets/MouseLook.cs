using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public Transform playerBody;
    public float _mouseSensitivity = 100f;

    private float _xRotation = 0f;



    void Start()
    {
        //Reset Cursor position
        Cursor.lockState = CursorLockMode.Locked;
    }


    void Update()
    {
        //Mouse look inputs
        float mouseX = Input.GetAxis("Mouse X") * _mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * _mouseSensitivity * Time.deltaTime;
        _xRotation -= mouseY;

        //Clamp mouse look rotation
        _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);

    }
}
