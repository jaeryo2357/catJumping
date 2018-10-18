using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autoCloud : MonoBehaviour {

    float turnTime;
    int key = 1;
    
    float span=0.0f;
    GameObject catt;
    Collision2D cat =null;
    Collider2D can = null;
  
    // Use this for initialization
    void Start () {

        this.catt = GameObject.Find("cat");
        turnTime =1.2f;

  
	}
	
	// Update is called once per frame
	void Update () {

        if ((catt.transform.position.y - this.transform.position.y) > 10.0f)
            Destroy(gameObject);

        span += Time.deltaTime;

        if (span > turnTime)
        {
            key *= -1;
            span = 0.0f;

        }
        else
        {

            //cat이 trigger로 바뀌면서 exit함수를 호출하지 못합니다.
            if (cat != null)
            {
                if (cat.transform.position.y - this.transform.position.y > 1)
                {
                    cat = null;
                }else
                cat.transform.Translate(key * 0.03f, 0, 0);
            }
            if (can != null)
                can.transform.Translate(key * 0.03f, 0, 0);
            this.transform.Translate(key * 0.03f, 0, 0);

            if (this.transform.position.x -0.05f<-2.5 || this.transform.position.x+0.05f > 2.5f)//화면 범위를 넘을 때
            {
    
                key *= -1;
                span = 0.0f;
            }
               
            
        }

        

    }

   


    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.transform.position.y > this.transform.position.y)
            this.cat = collision;
        else
            cat = null;
    }
   
    private void OnCollisionExit2D(Collision2D collision)
    {
        this.cat = null;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.tag=="can")
        this.can = other;
    }
}
