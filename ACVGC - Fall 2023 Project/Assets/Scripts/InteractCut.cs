using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractCut : MonoBehaviour
{
    public PlayerControllerNew playerA;
    public SpriteRenderer OBJrendererA;
    public float CrateID;
    public Sprite food;
    public bool MeatTime;

    void OnTriggerStay2D(Collider2D collison)
    {
        if (collison.gameObject.tag == "BulletA" && playerA.ishold == true && playerA.ObjID == 2)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                playerA.ObjID = CrateID;
                playerA.ishold = true;
                OBJrendererA.sprite = food;
            }
        }
    }
}
