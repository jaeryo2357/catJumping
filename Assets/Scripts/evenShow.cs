using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class evenShow : MonoBehaviour {

    bool tshow = false; //점수 시간
    float span=0.0f;
    
    
    bool eshow = false; //이펙트 시간
    float effectspan = 0.0f;
    int spot=0;
  
	// Use this for initialization
	void Start () {
 
    
	}
	
	// Update is called once per frame
	void Update () {

      

        if (tshow)
        {
            span += Time.deltaTime;
            this.GetComponent<Text>().text = "+" + spot;
            if (span >1.2f)
            {
                tshow = false;
                spot = 0;
                span = 0.0f;
            }
          
        }
        else
        {
            this.GetComponent<Text>().text = "";
            
        }

        if(eshow)
        {
            effectspan += Time.deltaTime;
            if(effectspan>1.2f)
            {
                eshow = false;
                effectspan = 0.0f;
            }else
            this.GetComponent<Text>().text ="Slow";
        }
	}

    public void show(int s)
    {
        if (s != 0)
        {
            tshow = true;
            spot = s;
            span = 0.0f;
        }
    }

    public void showEffect()
    {
       
        eshow = true;
        effectspan = 0.0f;
    }
}
