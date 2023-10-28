using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class IS_CharacterController : MonoBehaviour
{

    //Movement
    public float speed;
    public float jump;
    float moveVelocity;
    public InputAction playerMovement;
    public InputAction playerJump;

    Vector2 moveDirection;

    private void OnEnable()
    {
        playerMovement.Enable();
    }

    private void OnDiable()
    {
        playerMovement.Disable();
    }

    public enum ObjectState
    {
        Ground,
        Jump,
        Finished
    }

    public ObjectState currentState;

    void Update()
    {
        switch (currentState)
        {
            case ObjectState.Ground:
                UpdateGround();
                break;

            case ObjectState.Jump:
                UpdateJump();
                break;

            case ObjectState.Finished:
                UpdateFinished();
                break;
        }

        moveVelocity = 0;
        moveDirection = playerMovement.ReadValue<Vector2>();
        speed = speed * moveDirection.x;
        moveVelocity = speed;
    }

    void UpdateJump()
    {
        //PlayerA's Left Right Movement
        //if (gameObject.tag == "PlayerA" && Input.GetKey(KeyCode.A)) //|| Input.GetKey(KeyCode.A))
        //{
           // moveVelocity = -speed;
            //transform.localRotation = Quaternion.Euler(0, 180, 0);
            //_renderer.flipX = false;
        //}

        GetComponent<Rigidbody2D>().velocity = new Vector2(moveVelocity, GetComponent<Rigidbody2D>().velocity.y);
    }

    void UpdateGround()
    {
        //Jumping
        //if (Input.GetKeyDown(KeyCode.W) && gameObject.tag == "PlayerA") //|| Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.W) )
        //{
           // GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jump);
            //currentState = ObjectState.Jump;
       // }

        GetComponent<Rigidbody2D>().velocity = new Vector2(moveVelocity, GetComponent<Rigidbody2D>().velocity.y);

    }

    void UpdateFinished()
    {
        speed = 0;
        jump = 0;
    }

    void OnCollisionEnter2D(Collision2D collison)
    {
        if (collison.gameObject.tag == "Ground")
        {
            currentState = ObjectState.Ground;
        }
        if (collison.gameObject.tag == "Good")
        {
            currentState = ObjectState.Finished;
        }
        if (collison.gameObject.tag == "BulletA")
        {
            Debug.Log ("Player hit");
        }
    }
}
