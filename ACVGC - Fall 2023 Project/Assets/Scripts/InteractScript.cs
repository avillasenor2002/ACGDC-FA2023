using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractScript : MonoBehaviour
{
    public GameObject IndicatorUI;
    public GameObject IndicatorUIHold;
    public Sprite F;
    public Sprite O;
    public bool isplayerF;
    public SpriteRenderer objrenderer;
    public PlayerControllerNew player;

    // Start is called before the first frame update
    void Start()
    {
        if (this.gameObject.tag == "BulletA")
        {
            objrenderer.sprite = F;
            isplayerF = true;
        }
        else if (this.gameObject.tag == "BulletB")
        {
            objrenderer.sprite = O;
            isplayerF = false;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collison)
    {
        //Crate Collision
        if (collison.gameObject.tag == "InteractObj" && player.ObjID == 0)
        {
            if (player.ishold == true)
            {
                IndicatorUIHold.SetActive(true);
            }
            else
            {
                IndicatorUI.SetActive(true);
            }
        }

        //Trash Collision
        if (collison.gameObject.tag == "Trash" && player.ObjID > 0)
        {
            if (player.ishold == true)
            {
                IndicatorUIHold.SetActive(true);
            }
            else
            {
                IndicatorUI.SetActive(true);
            }
        }

        //Cauldron Collision
        if (collison.gameObject.tag == "Submit" && player.ObjID > 0)
        {
            if (player.ishold == true)
            {
                IndicatorUIHold.SetActive(true);
            }
            else
            {
                IndicatorUI.SetActive(true);
            }
        }

        //Oven Collision
        if (collison.gameObject.tag == "Oven" && this.gameObject.tag == "BulletB" && player.ObjID == 1)
        {
            if (player.ishold == true)
            {
                IndicatorUIHold.SetActive(true);
            }
            else
            {
                IndicatorUI.SetActive(true);
            }
        }

        //Citting Board Collision
        if (collison.gameObject.tag == "Cut" && this.gameObject.tag == "BulletA" && player.ObjID == 2)
        {
            if (player.ishold == true)
            {
                IndicatorUIHold.SetActive(true);
            }
            else
            {
                IndicatorUI.SetActive(true);
            }
        }
    }
    void OnTriggerExit2D(Collider2D collison)
    {
            IndicatorUI.SetActive(false);
            IndicatorUIHold.SetActive(false);
    }
}