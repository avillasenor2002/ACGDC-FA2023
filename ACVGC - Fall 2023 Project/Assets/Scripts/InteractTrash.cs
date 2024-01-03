using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractTrash : MonoBehaviour
{
    public PlayerControllerNew playerA;
    public PlayerControllerNew playerB;
    public float CrateID;

    void OnTriggerStay2D(Collider2D collison)
    {
        //Crate Collision
        if (collison.gameObject.tag == "BulletA" && playerA.ishold == true)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                playerA.ObjID = CrateID;
                playerA.ishold = false;
            }
        }
        else if (collison.gameObject.tag == "BulletB" && playerB.ishold == true)
        {
            if (Input.GetKeyDown(KeyCode.RightShift))
            {
                playerB.ObjID = CrateID;
                playerB.ishold = false;
            }
        }
    }
}
