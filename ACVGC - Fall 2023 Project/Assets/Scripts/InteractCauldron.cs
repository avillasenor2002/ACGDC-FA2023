using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class InteractCauldron : MonoBehaviour
{
    public PlayerControllerNew playerA;
    public PlayerControllerNew playerB;
    public float CrateID;
    public GameManager gameManager;

    void OnTriggerStay2D(Collider2D collison)
    {
        //Crate Collision
        if (collison.gameObject.tag == "BulletA" && playerA.ishold == true)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                gameManager.playerObjID = playerA.ObjID;
                gameManager.currentState = GameManager.ObjectState.ObjCheck;
                //playerA.ishold = false;
                gameManager.taskcomplete = true;
            }
        }
        else if (collison.gameObject.tag == "BulletB" && playerB.ishold == true)
        {
            if (Input.GetKeyDown(KeyCode.RightShift))
            {
                gameManager.playerObjID = playerA.ObjID;
                gameManager.currentState = GameManager.ObjectState.ObjCheck;
                //playerB.ishold = false;
                gameManager.taskcompleteB = true;
            }
        }
    }
}
