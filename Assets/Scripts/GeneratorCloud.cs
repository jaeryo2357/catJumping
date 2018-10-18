using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorCloud : MonoBehaviour {

    public GameObject[] clouds;
    public GameObject can;
    GameObject cat;
   
    float span = 0.0f;
    float px;
	// Use this for initialization
	void Start () {
        cat = GameObject.Find("cat");
	}
	
	// Update is called once per frame
	void Update () {

        if (this.transform.position.y - cat.transform.position.y < 15.0f)
        {
            span += Time.deltaTime;
            if (span > 0.2f)
            {
                span = 0.0f;

                px = Random.Range(-2.2f, 2.2f);
                if (Random.Range(0, 13) == 1)
                {
                    GameObject c = Instantiate(can) as GameObject;
                    c.transform.position= new Vector3(px, this.transform.position.y+0.2f , 0);

                }
                int gr = Random.Range(0, clouds.Length);
                GameObject cloud = Instantiate(clouds[gr]) as GameObject;


                cloud.transform.position = new Vector3(px, this.transform.position.y-0.2f, 0);
            }
            transform.Translate(0, 0.12f, 0);

        }
	}
}
