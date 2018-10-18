using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rainCloud : MonoBehaviour {


    GameObject cat;
    public GameObject rain;
    float span = 0.0f;//비의 간격

    float rainning = 0.0f;//rainning의 간격

    bool Ranning = true; //비가 내리는 간격

    // Use this for initialization
    void Start()
    {
        cat = GameObject.Find("cat");
    }

    // Update is called once per frame
    void Update()
    {
        if ((cat.transform.position.y - this.transform.position.y) > 10.0f)
            Destroy(gameObject);

        if(Ranning)
        {
            rainning += Time.deltaTime;
            if (rainning > 3.3f)
            {
                Ranning = false;
                rainning = 0.0f;
            }
            else
            {
                span += Time.deltaTime;
                if (span > 0.3f)
                {
                    span = 0.0f;
                    GameObject cloud = Instantiate(rain) as GameObject;
                    //구름 간격사이에서만 비가 내리게 하기
                    float px = Random.Range(this.transform.position.x + this.GetComponent<BoxCollider2D>().size.x / 2 * -1, this.transform.position.x + this.GetComponent<BoxCollider2D>().size.x / 2);

                    cloud.transform.position = new Vector3(px, this.transform.position.y - 0.2f, 0);
                }
            }
        }
        else
        {
            rainning += Time.deltaTime;
            if(rainning>5.0f)
            {
                rainning = 0.0f;
                Ranning = true;
            }
        }
    }
}
