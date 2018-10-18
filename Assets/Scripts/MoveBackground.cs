using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour {

    public GameObject b1;

    public GameObject b2;
    GameObject under=null;
    GameObject up=null;
    GameObject superUP = null;
    GameObject cat;
    // Use this for initialization
    void Start () {
        cat = GameObject.Find("cat");


        UPDownCheck();
    }
	void UPDownCheck()
    {
       if(b1.transform.position.y>transform.position.y&&transform.position.y>b2.transform.position.y)
        {
            up = b1;
            under = b2;
            superUP = null;
        }else if(b2.transform.position.y > transform.position.y && transform.position.y > b1.transform.position.y)
        {
            up = b2;
            under = b1;
            superUP = null;
        }
        else if(b2.transform.position.y>transform.position.y&&b1.transform.position.y>transform.position.y)
        {
            if (b1.transform.position.y > b2.transform.position.y)
            {
                superUP = b1;
                up = b2;
            }
            else
            {
                superUP = b2;
                up = b1;
            }
        }
        else
        {
            superUP = null;
            up = null;
            under = null;
        }
    }
	// Update is called once per frame
	void Update () {
        UPDownCheck();
        if (cat.transform.position.y>this.transform.position.y+3.0f)
        {
            if (under != null && up != null)
            {
                under.transform.position = new Vector3(this.transform.position.x, up.transform.position.y + 13f, 0);
               
            }
          
        }
        else if(cat.transform.position.y<this.transform.position.y)
        {
            if (superUP != null)
                superUP.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - 13.2f, 0);
        }
    }

    int YCheck(GameObject t)
    {
        if (t.transform.position.y+3.0f > this.transform.position.y)
            return 1;
        else if (t.transform.position.y < this.transform.position.y)
            return -1;
        return 0;
     }
}
