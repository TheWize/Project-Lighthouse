using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController _controller;
    private float _directionY;

    [SerializeField]
    private float _jumpSpeed = 2f;
    [SerializeField]
    private float _gravity = 9.81f;
    [SerializeField]
    private float _moveSpeed = 4f;
    [SerializeField]
    private bool _isGrounded;

    Vector3 direction;

    void Start()
    {
        //Assign _controller to CharacterController component
        _controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        //CharacterController Inputs
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        //Movement Vector
        direction = transform.right * horizontalInput + transform.forward * verticalInput;
        direction.Normalize();

        _isGrounded = _controller.isGrounded;
        if (_controller.isGrounded)
        {
            _directionY = 0;
            //Jumping feature
            if (Input.GetButtonDown("Jump"))
            {
                _directionY = _jumpSpeed;
            }

            if (Input.GetButtonDown("Shift"))
            {

            }
        }
            
        _directionY -= _gravity * Time.deltaTime;
        direction.y = _directionY;
        _controller.Move(direction * _moveSpeed * Time.deltaTime);
    }
}
