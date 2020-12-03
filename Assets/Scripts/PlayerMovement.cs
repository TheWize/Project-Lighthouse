using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController _controller;
    private float _directionY;

    [SerializeField]
    private float _jumpForce; //2f
    private const float GRAVITY = 9.81f;
    [SerializeField]
    private float _walkSpeed; //10.5f
    [SerializeField]
    private float _runSpeed; // 15f
    public bool _isGrounded;
    private readonly KeyCode _runningButton = KeyCode.LeftShift;
    private bool IsRunning { get => Input.GetKey(_runningButton); }
    Vector3 direction;

    void Start()
    {
        _isGrounded = false;
        //Assign _controller to CharacterController component
        _controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        //CharacterController Inputs
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        _isGrounded = _controller.isGrounded;

        //Movement Vector
        direction = transform.right * horizontalInput + transform.forward * verticalInput;
        direction.Normalize();
        //_isGrounded = _controller.isGrounded;
        if (_isGrounded)
        {
            _directionY = -GRAVITY * Time.deltaTime;
            //Jumping feature
            if (Input.GetButtonDown("Jump"))
            {
                _directionY += _jumpForce;
            }
        }
            
        _directionY -= GRAVITY * Time.deltaTime;
        direction.y = _directionY;
        _controller.Move(direction * (IsRunning ? _runSpeed : _walkSpeed) * Time.deltaTime);
    }
}
