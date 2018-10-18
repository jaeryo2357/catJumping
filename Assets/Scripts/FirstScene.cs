using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstScene : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
        PlayerPrefs.SetInt("HighScore", 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
           
            SceneManager.LoadScene("explanScene");
        }
        
    }
}
