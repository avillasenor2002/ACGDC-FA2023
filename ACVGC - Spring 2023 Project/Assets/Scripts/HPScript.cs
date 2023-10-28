using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class HPScript : MonoBehaviour
{
    //hitpoints is the player's current HP
    public float hitpoints;
    public float startinghp;
    public string ObjName;
    public GameObject end1;
    public GameObject end2;

    void awake()
    {
        //Set the starting HP of the player to the desired amount
        hitpoints = startinghp;
    }

    // Start is called before the first frame update
    void Start()
    {
        hitpoints = startinghp;
        if (this.gameObject.tag == "PlayerA")
        {
            ObjName = "PlayerA";
        }
        
        if (this.gameObject.tag == "PlayerB")
        {
            ObjName = "PlayerB";
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (hitpoints <= 0 && this.gameObject.tag == "PlayerA") 
        {
            Debug.Log("Player Has died");
            Destroy(GameObject.Find("- Player Alpha -"));
            end1.SetActive(true);
        }

        if (hitpoints <= 0 && this.gameObject.tag == "PlayerB")
        {
            Debug.Log("Player Has died");
            Destroy(GameObject.Find("- Player Brovo -"));
            end2.SetActive(true);
        }
    }

    void OnCollisionEnter2D(Collision2D collison)
    {
        //If the player collides with a bullet they will take damage
        if (this.gameObject.tag == "PlayerA" && collison.gameObject.tag == "BulletB")
        {
            hitpoints -= 1;
            Debug.Log("Player hit");
        }

        if (this.gameObject.tag == "PlayerB" && collison.gameObject.tag == "BulletA")
        {
            hitpoints -= 1;
            Debug.Log("Player hit");
        }
    }
    }
