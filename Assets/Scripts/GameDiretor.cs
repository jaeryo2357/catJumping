using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDiretor : MonoBehaviour {

    int Intscroe = 0;
    int dvider = 0;
    bool once_fiver_jump = true;
    int spanScroe = 0;
    GameObject high;
    GameObject score=null;
    GameObject can = null;
    GameObject cat = null;
    public Sprite first;
    public Sprite fiverTime;
    float fiver_span = 0.0f;
    int can_get = 0;
    bool fiver = false;
    public GameObject b1, b2, b3;
    GameObject cg;
    // Use this for initialization

    void Start () {
        cg = GameObject.Find("GeneratorCloud");
        cat = GameObject.Find("cat");
        can = GameObject.Find("can_check");
        high = GameObject.Find("HighScore");
        score = GameObject.Find("Score");
        PlayerPrefs.SetInt("resultScore", Intscroe);

        
        GetComponent<AudioSource>().Play();
        PlayerPrefs.SetInt("HighScore", PlayerPrefs.GetInt("HighScore"));

        high.GetComponent<Text>().text = "최고:" + PlayerPrefs.GetInt("HighScore");
    }

    // Update is called once per frame
    void Update()
    {
        if (fiver)
        {
            fiver_span += Time.deltaTime;
            if (fiver_span < 5.2f)
            {
                cat.GetComponent<PlayerController>().notContral();
                cat.GetComponent<Rigidbody2D>().gravityScale = 1;
                cat.GetComponent<Rigidbody2D>().velocity = new Vector2(0, cat.GetComponent<Rigidbody2D>().velocity.y);
                if (once_fiver_jump)
                {
                    cat.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                    cat.GetComponent<Rigidbody2D>().AddForce(transform.up * 4550.0f);
                    once_fiver_jump = false;
                }
                cat.GetComponent<BoxCollider2D>().isTrigger = true;
                cat.GetComponent<CircleCollider2D>().isTrigger = true;
                cat.GetComponent<Animator>().SetBool("Jump", true);
                b1.GetComponent<SpriteRenderer>().sprite = fiverTime;
                b2.GetComponent<SpriteRenderer>().sprite = fiverTime;
                cg.transform.position = new Vector3(cg.transform.position.x, cat.transform.position.y + 15f, 0);
                b3.GetComponent<SpriteRenderer>().sprite = fiverTime;
            }
            else
            {
                cat.GetComponent<Animator>().SetBool("Jump", false);
                cat.GetComponent<PlayerController>().contralable();
                cat.GetComponent<Rigidbody2D>().gravityScale = 3;
                fiver_span = 0.0f;
                cat.GetComponent<BoxCollider2D>().isTrigger = false;
                cat.GetComponent<CircleCollider2D>().isTrigger = false;
                once_fiver_jump = true;
                b1.GetComponent<SpriteRenderer>().sprite = first;
                b2.GetComponent<SpriteRenderer>().sprite = first;
                b3.GetComponent<SpriteRenderer>().sprite = first;
                fiver = false;

            }
        }
        can.GetComponent<Text>().text = can_get + "/4";

        if (spanScroe > 0)
        {
            if (spanScroe < dvider)
            {
                Intscroe += spanScroe;
                spanScroe = 0;

            }
            else
            {
                Intscroe += dvider;
                spanScroe -= dvider;
            }

        }

        if (Intscroe > 1000)
        {
            score.GetComponent<Text>().text = "" + Intscroe / 1000 + "k" + Intscroe % 1000;
            score.GetComponent<Text>().fontSize = 30;
           
        }
        else
        {
            score.GetComponent<Text>().text = "" + Intscroe;
            

        }
        PlayerPrefs.SetInt("resultScore", Intscroe);
        if (Intscroe > PlayerPrefs.GetInt("HighScore"))
                PlayerPrefs.SetInt("HighScore", Intscroe);
        high.GetComponent<Text>().text = "Best:" + PlayerPrefs.GetInt("HighScore");

        
    }
    public void AddCan()
    {
        can_get++;
        if(can_get==4)
        {
            fiver = true;
            can_get = 0;
            //피버타임
        }
    }
    public void AddScore(int s)
    {
        dvider = s / 3;   
        spanScroe = s;
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
