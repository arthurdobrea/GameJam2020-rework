using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
    private float normalSpeed = 4;
    private float runSpeed = 7;
    private float rotationSpeed = 80;
    private float rot = 0;
    private float gravity = 8;

    private Vector3 moveDir = Vector3.zero;
    public CharacterController characterController;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // private void move()
    // {
    //     // if (characterController.isGrounded)
    //     {
    //         if (Input.GetKey(KeyCode.W))
    //         {
    //             moveDir = calculateVectorOfMOveDirection(Vector3.forward);
    //         }
    //         else if(Input.GetKeyUp(KeyCode.W))
    //         {
    //             moveDir = calculateVectorOfMOveDirection(Vector3.zero);
    //         }
    //
    //         if (Input.GetKey(KeyCode.S))
    //         {
    //             moveDir = calculateVectorOfMOveDirection(Vector3.back);
    //         }
    //
    //         if (Input.GetKey(KeyCode.D))
    //         {
    //             moveDir = calculateVectorOfMOveDirection(Vector3.right);
    //         }
    //
    //         if (Input.GetKey(KeyCode.A))
    //         {
    //             moveDir = calculateVectorOfMOveDirection(Vector3.left);
    //         }
    //
    //         moveCharachter(moveDir);
    //     }
    // }

    private Vector3 move()
    {
        return new Vector3(Input.GetAxisRaw("Horizontal"),0,Input.GetAxisRaw("Vertical"));
        
    }


    private Vector3 calculateVectorOfMOveDirection(Vector3 direction)
    {
        moveDir = direction;
        moveDir *= normalSpeed;
        moveDir = transform.TransformDirection(moveDir);
        return moveDir;
    }

    private void moveCharachter(Vector3 moveDir)
    {
        rot += Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;
        transform.eulerAngles = new Vector3(0, rot, 0);
        moveDir.y -= gravity * Time.deltaTime;
        characterController.Move(moveDir * Time.deltaTime);
    }

    void FixedUpdate()
    {
        move();
    }
}