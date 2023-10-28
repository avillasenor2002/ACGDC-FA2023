using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    public enum ObjectState
    {
        Falling,
        Landed,
        Collected
    }

    public ObjectState state;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case ObjectState.Falling:
                UpdateFalling();
                break;

            case ObjectState.Landed:
                UpdateLanded();
                break;

            case ObjectState.Collected:
                UpdateCollected();
                break;
        }
    }

    void UpdateFalling()
    {
    
    }

    void UpdateLanded()
    { 

    }

    void UpdateCollected()
    {

    }
}
