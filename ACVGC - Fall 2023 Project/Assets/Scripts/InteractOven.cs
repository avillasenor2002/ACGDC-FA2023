using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractOven : MonoBehaviour
{
    public PlayerControllerNew playerB;
    public SpriteRenderer OBJrendererB;
    public float CrateID;
    public Sprite food;
    public bool MeatTime;

    void OnTriggerStay2D(Collider2D collison)
    {
        if (collison.gameObject.tag == "BulletB" && playerB.ishold == true && playerB.ObjID == 1)
        {
            if (Input.GetKeyDown(KeyCode.RightShift))
            {
                playerB.ObjID = CrateID;
                playerB.ishold = true;
                OBJrendererB.sprite = food;
            }
        }
    }
}
