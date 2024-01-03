using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;

public class PlayerControllerNew : MonoBehaviour
{

    //Movement
    public float speed;
    public float jump;
    public float ObjID;
    public bool ishold;
    float moveVelocity;
    public Sprite idle;
    public Sprite idleArmUp;
    public Sprite air;
    public SpriteRenderer playersprite;
    public GameObject foodsprite;
    public GameObject meatsprite;
    

    public enum ObjectState
    {
        Ground,
        Jump,
        Finished
    }

    public ObjectState currentState;

    void Start()
    {
        ObjID = 0;
    }

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

        if (ishold == true)
        {
            playersprite.sprite = idleArmUp;
            
            if (ObjID == 1 || ObjID >=6)
            {
                meatsprite.SetActive(true);
            }
            else if (ObjID >= 2 && ObjID < 6)
            {
                foodsprite.SetActive(true);
            }
        }
        
        if (ishold == false)
        {
            playersprite.sprite = idle;
            ObjID = 0;
            meatsprite.SetActive(false);
            foodsprite.SetActive(false) ;
        }
    }

    void UpdateJump()
    {
        //PlayerA's Left Right Movement
        if (gameObject.tag == "PlayerA" && Input.GetKey(KeyCode.A)) //|| Input.GetKey(KeyCode.A))
        {
            moveVelocity = -speed;
            transform.localRotation = Quaternion.Euler(0, 180, 0);
            //_renderer.flipX = false;
        }
        if ( gameObject.tag == "PlayerA" && Input.GetKey(KeyCode.D)) //|| Input.GetKey(KeyCode.D))
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

    void UpdateGround()
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
