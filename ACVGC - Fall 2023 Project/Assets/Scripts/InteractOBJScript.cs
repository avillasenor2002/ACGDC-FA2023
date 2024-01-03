using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractOBJScript : MonoBehaviour
{
    public InteractScript playerHitA;
    public InteractScript playerHitB;
    public PlayerControllerNew playerA;
    public PlayerControllerNew playerB;
    public SpriteRenderer OBJrendererA;
    public SpriteRenderer OBJrendererB;
    public SpriteRenderer OBJrendererAMeat;
    public SpriteRenderer OBJrendererBMeat;
    public float CrateID;
    public Sprite food;
    public bool MeatTime;

    void OnTriggerStay2D(Collider2D collison)
    {
        //Crate Collision
        if (collison.gameObject.tag == "BulletA" && playerA.ishold == false)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                playerA.ObjID = CrateID;
                playerA.ishold = true;
                OBJrendererA.sprite = food;
                if (MeatTime == true)
                {
                    OBJrendererAMeat.sprite = food;
                }
            } 
        }
        else if (collison.gameObject.tag == "BulletB" && playerB.ishold == false)
        {
            if (Input.GetKeyDown(KeyCode.RightShift))
            {
                playerB.ObjID = CrateID;
                playerB.ishold = true;
                OBJrendererB.sprite = food;
                if (MeatTime == true)
                {
                    OBJrendererBMeat.sprite = food;
                }
            } 
        }
    }
}