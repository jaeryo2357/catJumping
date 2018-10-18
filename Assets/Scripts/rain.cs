using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rain : MonoBehaviour {

    float firsty;
    GameObject effecttext=null;
	// Use this for initialization
	void Start () {
        firsty = this.transform.position.y;
        
	}
	
	// Update is called once per frame
	void Update () {
        if (this.transform.position.y < firsty - 5.0f)
            Destroy(gameObject);
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.Equals(GameObject.Find("cat")))
        {
            if (collision.GetComponent<PlayerController>().GetContral() == true)
            {
                //힘 감소시키기
                effecttext = GameObject.Find("ShowText");
                effecttext.GetComponent<evenShow>().showEffect();
                if (this.transform.position.y - collision.GetComponent<PlayerController>().transform.position.y > 80.0f) 
                collision.GetComponent<Rigidbody2D>().velocity = new Vector3(collision.GetComponent<Rigidbody2D>().velocity.x * 0.15f,collision.GetComponent<Rigidbody2D>().velocity.y * 0.17f, 0);
                Destroy(gameObject);
            }
        }

        
    }
}
