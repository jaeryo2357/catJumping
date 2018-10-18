using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalCloud : MonoBehaviour {

    GameObject cat;
	// Use this for initialization
	void Start () {
        cat = GameObject.Find("cat");
	}
	
	// Update is called once per frame
	void Update () {
        if ((cat.transform.position.y - this.transform.position.y) > 10.0f)
            Destroy(gameObject);
    }
 
}
