using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController _controller;

    [SerializeField]
    private float _jumpSpeed = 2f;
    [SerializeField]
    private float _gravity = 9.81f;
    [SerializeField]
    private float _moveSpeed = 4f;
  
    private float _directionY;
 
    void Start()
    {
        //Assign _controller to CharacterController component
        _controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        //CharacterController Inputs
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        //Movement Vector
        Vector3 direction = transform.right * horizontalInput + transform.forward * verticalInput;
        direction.Normalize();

        //Jumping feature
        if (_controller.isGrounded)
        {
            if (Input.GetButtonDown("Jump"))
            {
                _directionY = _jumpSpeed;
            }
        }

        _directionY -= _gravity * Time.deltaTime;
         direction.y = _directionY;
        _controller.Move(direction * _moveSpeed * Time.deltaTime);
    }
}
