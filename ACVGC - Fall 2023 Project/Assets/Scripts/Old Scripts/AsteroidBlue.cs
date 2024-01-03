using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidBlue : MonoBehaviour
{
    //VARIABLES
    //public GameObject score; 

    //public ScoreScript      scoreScript; 

    public GameObject mediumAsteroidPrefab;
    
    public Rigidbody2D asteroidRigidbody2D;

    public float            speed;

    public int              scoreValue;

    
    // Start is called before the first frame update
    void Start()
    {
        //scoreScript = score.GetComponent<ScoreScript>();
        this.transform.Rotate(0,0,Random.Range(0, 360));
        asteroidRigidbody2D.AddForce(this.transform.up * speed);    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collison)
    {
        if (collison.gameObject.tag == "Player")
        {
            Debug.Log("yeah this works");
            Destroy(GameObject.Find("Player"));
            //Set GameOver Text & button to active
            //Instantiate(GameObject.Find("Sortero__Mission_Failed"), new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        }
        //If the asteroid crashes into wall, add force in opposite direction!
        if (collison.gameObject.tag == "Wall")
        {
            asteroidRigidbody2D.AddForce((transform.up * -1) * speed);
        }
        //If asteroid hits bullet, destroy and spawn two smaller asteroids
        if (collison.gameObject.tag == "KillWallR")
        {
            Destroy(this.gameObject);
        }
    }


}
