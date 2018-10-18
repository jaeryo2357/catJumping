using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperCloud : MonoBehaviour {
    GameObject cat;
    Animator animator;
  
	// Use this for initialization
	void Start () {
        this.animator = GetComponent<Animator>();
        this.cat = GameObject.Find("cat");
    }
	
	// Update is called once per frame
	void Update () {
        if ((cat.transform.position.y - this.transform.position.y) > 10.0f)
            Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
      
            if (collision.transform.position.y > this.transform.position.y)
            {
                this.animator.SetBool("Onit", true);
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * 400.0f);
                collision.gameObject.GetComponent<Animator>().SetBool("Jump", true);
            }
        
       
            
        
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
       
        this.animator.SetBool("Onit", false);
    }
}
