using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController _controller;
    private float directionY;

    [SerializeField]
    public float _moveSpeed;
    [SerializeField]
    private float _gravity;
    [SerializeField]
    private float _jumpSpeed;  

    void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        //Input for CharacterController component
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        //Movement Vector
        Vector3 direction = new Vector3(horizontalInput, 0, verticalInput);
        _controller.Move(direction * _moveSpeed * Time.deltaTime);

        direction.y = directionY;

        //Add gravity
        directionY -= _gravity * Time.deltaTime;

        //Jump
        if(Input.GetButtonDown("Jump"))
        {
            directionY = _jumpSpeed;
        }
 
    }
  

}
