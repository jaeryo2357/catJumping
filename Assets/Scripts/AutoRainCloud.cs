using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoRainCloud : MonoBehaviour {

    float turnTime;
    int key = 1;
    float span = 0.0f;//움직임
    GameObject catt;
    Collision2D cat = null;
    public GameObject rain;
    float spanRain = 0.0f;//비의 간격
    Collider2D can;
    float rainning = 0.0f;//rainning의 간격

    bool Ranning = true; //비가 내리는 간격
 
    // Use this for initialization
    void Start()
    {
        catt = GameObject.Find("cat");
        turnTime = 1.2f;
    }

    // Update is called once per frame
    void Update()
    {
        if ((catt.transform.position.y - this.transform.position.y) > 10.0f)
            Destroy(gameObject);

        // 자동으로 움직이는 부분---------------------------------------------------

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
                }
                else
                    cat.transform.Translate(key * 0.03f, 0, 0);
            }
            if (can != null)
                can.transform.Translate(key * 0.03f, 0, 0);
            this.transform.Translate(key * 0.03f, 0, 0);

            if (this.transform.position.x - 0.05f < -2.5 || this.transform.position.x + 0.05f > 2.5f)//화면 범위를 넘을 때
            {

                key *= -1;
                span = 0.0f;
            }



            //비가 내리는 부분 -----------------------------------------------------------------
            if (Ranning)
            {
                rainning += Time.deltaTime;
                if (rainning > 3.3f)
                {
                    Ranning = false;
                    rainning = 0.0f;
                }
                else
                {
                    spanRain += Time.deltaTime;
                    if (spanRain > 0.3f)
                    {
                        spanRain = 0.0f;
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
                if (rainning > 5.0f)
                {
                    rainning = 0.0f;
                    Ranning = true;
                }
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
        if (other.gameObject.tag == "can")
            this.can = other;
    }
}
