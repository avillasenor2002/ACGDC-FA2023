using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{

    public float            speed;

    public Transform player;

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(0, 0, -speed);
        transform.position = new Vector3(player.position.x, player.position.y - 1, 0); // Camera follows the player but 6 to the right
    }

}
