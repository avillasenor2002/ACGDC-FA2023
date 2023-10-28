using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject RedDewbot;
    public float randomspwn;

    // Start is called before the first frame update
    void Start()
    {
        randomspwn = UnityEngine.Random.Range(1, 4);

        if (randomspwn == 1)
        {
            Instantiate(RedDewbot, new Vector3(0, 3, 0), Quaternion.identity);
        }

        if (randomspwn == 2)
        {
            Instantiate(RedDewbot, new Vector3(-6, 0, 0), Quaternion.identity);
        }

        if (randomspwn == 3)
        {
            Instantiate(RedDewbot, new Vector3(6, 0, 0), Quaternion.identity);
        }

        if (randomspwn == 4)
        {
            Instantiate(RedDewbot, new Vector3(0, 3, 0), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collison)
    {
        if (collison.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }
}
