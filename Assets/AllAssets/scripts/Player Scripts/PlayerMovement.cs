using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {


    private CharacterController characterController;
    private Vector3 moveDirection;
    private float gravity = 20;
    private float verticalVelocity;

    public float speed = 5;
    public float jumpForce = 10;

    void Awake(){

        characterController = GetComponent<CharacterController>();

    }

	void Update () {
        MoveThePlayer();
	}

    private void MoveThePlayer(){

        moveDirection = new Vector3(Input.GetAxis(Axis.HORIZONTAL),0f,
                                    Input.GetAxis(Axis.VERTICAL));

        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= speed * Time.deltaTime;

        ApplyGravity();

        characterController.Move(moveDirection);
        
    }

    private void ApplyGravity()
    {   
        verticalVelocity -= gravity * Time.deltaTime;
        
        PlayerJump();
                  
        moveDirection.y = verticalVelocity * Time.deltaTime;

    }

    private void PlayerJump(){

        if(characterController.isGrounded && Input.GetKeyDown(KeyCode.Space)) {
            verticalVelocity = jumpForce;        
        }
    }

}
