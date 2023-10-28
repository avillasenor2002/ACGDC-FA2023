using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwap : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake()
    {
        SceneManager.LoadScene("CC_Battle!");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
