using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovementAnimated : MonoBehaviour
{
    public Rigidbody2D shipRigidbody;

    public float speed;
    public float torqueSpeed;

    public AudioSource sfxAudioSource;

    public AudioClip teleportSFX;

    public GameObject Winstate1;
    public GameObject Winstate2;

    public Animator shipAnimator;
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            shipRigidbody.AddForce(this.transform.up * speed);
            shipAnimator.SetTrigger("Go");
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            shipRigidbody.AddTorque(torqueSpeed);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            shipRigidbody.AddTorque(torqueSpeed * -1);
        }
        if (Input.GetKey(KeyCode.Tab))
        {
                   Winstate1.SetActive(true);
                   Winstate2.SetActive(true); 
        }

    }
    public void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            shipAnimator.SetTrigger("Stop");
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
           TeleportShip (this.transform);
        }
    }

    public void TeleportShip (Transform ship)
    {
        //Set the bounds
        //float xBounds = Random.Range(-8, 8);
        float xBounds = UnityEngine.Random.Range(-8, 8);
        //float yBounds = Random.Range(-4, 4);
        float yBounds = UnityEngine.Random.Range(-4, 4);

        //Set Teleport Position
        Vector3 teleportPos = new Vector3(xBounds, yBounds, 0);

        ship.position = new Vector3(xBounds, yBounds, 0);
        sfxAudioSource.clip = teleportSFX;
        sfxAudioSource.Play();
    }
}

