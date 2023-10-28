using UnityEngine;
using System.Collections;

public class ControllerTanuki: MonoBehaviour
{

    //Movement
    public float speed;
    public float jump;
    public float glide;
    float moveVelocity;

    public enum ObjectState
    {
        Ground1,
        Jump,
        Jump2,
        Finished1
    }

    public ObjectState currentState;

    void Update()
    {
        switch (currentState)
        {
            case ObjectState.Ground1:
                UpdateGround1();
                break;

            case ObjectState.Jump:
                UpdateJump();
                break;

            case ObjectState.Jump2:
                UpdateJump2();
                break;

            case ObjectState.Finished1:
                UpdateFinished1();
                break;
        }

        moveVelocity = 0;
    }

    void UpdateJump()
    {
       //Jumping
        if (Input.GetKeyDown(KeyCode.W) && gameObject.tag == "PlayerA") //|| Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.W) )
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, glide);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && gameObject.tag == "PlayerB") //|| Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.W) )
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, glide);
        }

        //PlayerA's Left Right Movement
        if (gameObject.tag == "PlayerA" && Input.GetKey(KeyCode.A)) //|| Input.GetKey(KeyCode.A))
        {
            moveVelocity = -speed;
            transform.localRotation = Quaternion.Euler(0, 180, 0);
            //_renderer.flipX = false;
        }
        if (gameObject.tag == "PlayerA" && Input.GetKey(KeyCode.D)) //|| Input.GetKey(KeyCode.D))
        {
            moveVelocity = speed;
            transform.localRotation = Quaternion.Euler(0, 0, 0);
            //_renderer.flipX = true;
        }

        //PlayerB's Left Right Movement
        if (gameObject.tag == "PlayerB" && Input.GetKey(KeyCode.LeftArrow)) //|| Input.GetKey(KeyCode.A))
        {
            moveVelocity = -speed;
            transform.localRotation = Quaternion.Euler(0, 180, 0);
            //_renderer.flipX = false;
        }
        if (gameObject.tag == "PlayerB" && Input.GetKey(KeyCode.RightArrow)) //|| Input.GetKey(KeyCode.D))
        {
            moveVelocity = speed;
            transform.localRotation = Quaternion.Euler(0, 0, 0);
            //_renderer.flipX = true;
        }

        GetComponent<Rigidbody2D>().velocity = new Vector2(moveVelocity, GetComponent<Rigidbody2D>().velocity.y);
    }

    void UpdateJump2()
    {

    }

    void UpdateGround1()
    {
        //Jumping
        if (Input.GetKeyDown(KeyCode.W) && gameObject.tag == "PlayerA") //|| Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.W) )
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jump);
            currentState = ObjectState.Jump;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && gameObject.tag == "PlayerB") //|| Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.W) )
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jump);
            currentState = ObjectState.Jump;
        }

        //PlayerA's Left Right Movement
        if (gameObject.tag == "PlayerA" && Input.GetKey(KeyCode.A)) //|| Input.GetKey(KeyCode.A))
        {
            moveVelocity = -speed;
            transform.localRotation = Quaternion.Euler(0, 180, 0);
            //_renderer.flipX = false;
        }
        if (gameObject.tag == "PlayerA" && Input.GetKey(KeyCode.D)) //|| Input.GetKey(KeyCode.D))
        {
            moveVelocity = speed;
            transform.localRotation = Quaternion.Euler(0, 0, 0);
            //_renderer.flipX = true;
        }

        //PlayerB's Left Right Movement
        if (gameObject.tag == "PlayerB" && Input.GetKey(KeyCode.LeftArrow)) //|| Input.GetKey(KeyCode.A))
        {
            moveVelocity = -speed;
            transform.localRotation = Quaternion.Euler(0, 180, 0);
            //_renderer.flipX = false;
        }
        if (gameObject.tag == "PlayerB" && Input.GetKey(KeyCode.RightArrow)) //|| Input.GetKey(KeyCode.D))
        {
            moveVelocity = speed;
            transform.localRotation = Quaternion.Euler(0, 0, 0);
            //_renderer.flipX = true;
        }

        GetComponent<Rigidbody2D>().velocity = new Vector2(moveVelocity, GetComponent<Rigidbody2D>().velocity.y);

    }

    void UpdateFinished1()
    {
        speed = 0;
        jump = 0;
    }

    void OnCollisionEnter2D(Collision2D collison)
    {
        if (collison.gameObject.tag == "Ground")
        {
            currentState = ObjectState.Ground1;
        }
        if (collison.gameObject.tag == "Good")
        {
            currentState = ObjectState.Finished1;
        }
    }
}