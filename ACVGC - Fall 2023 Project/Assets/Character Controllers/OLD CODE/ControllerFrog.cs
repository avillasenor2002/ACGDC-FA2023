using UnityEngine;
using System.Collections;

public class FrogPlayerController: MonoBehaviour
{

    //Movement
    public float speed;
    public float jump;
    float moveVelocity;

    public enum ObjectState
    {
        Ground1,
        Jump1,
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

            case ObjectState.Jump1:
                UpdateJump1();
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

    void UpdateJump1()
    {
        //Jumping
        if (Input.GetKeyDown(KeyCode.W) && gameObject.tag == "PlayerA")
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jump);
            currentState = ObjectState.Jump2;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && gameObject.tag == "PlayerB")
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jump);
            currentState = ObjectState.Jump2;
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

    void UpdateGround1()
    {
        //Jumping
        if (Input.GetKeyDown(KeyCode.W) && gameObject.tag == "PlayerA")
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jump);
            currentState = ObjectState.Jump1;
        }

        //Jumping
        if (Input.GetKeyDown(KeyCode.UpArrow) && gameObject.tag == "PlayerB")
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jump);
            currentState = ObjectState.Jump1;
        }

        //PlayerA's Left Right Movement
        if (gameObject.tag == "PlayerA" && Input.GetKey(KeyCode.A)) //|| Input.GetKey(KeyCode.A))
        {
            moveVelocity = -speed;
            this.transform.localRotation = Quaternion.Euler(0, 180, 0);
            //_renderer.flipX = false;
        }
        if (gameObject.tag == "PlayerA" && Input.GetKey(KeyCode.D)) //|| Input.GetKey(KeyCode.D))
        {
            moveVelocity = speed;
            this.transform.localRotation = Quaternion.Euler(0, 0, 0);
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