using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
    Rigidbody2D rigid2D;
    BoxCollider2D box;
    CircleCollider2D circle;
    Animator animator;
    GameObject Director;
    bool can_ones = true;
    public GameObject evenScore;
    bool Jumping = false;
    float jump = 680.0f;
    float walkForce = 30.0f;
    float beforeY = -3.61f;
    float maxWalkSpeed = 2.0f;
    int key = 0;
    public Text elementalText;
    [SerializeField]
    public new Camera camera;
    private Transform target;
    bool contral = true;
  
    // 키를 계속 누르면 값이 증가하여 Max 제한
    // Use this for initialization
    void Start () {
        this.rigid2D = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
        this.box = GetComponent<BoxCollider2D>();
        this.circle = GetComponent<CircleCollider2D>();
        this.animator.SetBool("Walking", false);
        this.animator.SetBool("Jump", false);
        Director = GameObject.Find("GameDirector");
        target = GetComponent<Transform>();
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 screenPos = camera.WorldToScreenPoint(new Vector3(target.position.x+0.4f,target.position.y+0.5f,0));

        float x = screenPos.x;

        //점수 text 플레이어 위 고정
        elementalText.transform.position = new Vector3(x, screenPos.y, elementalText.transform.position.z);
      

        if (this.rigid2D.velocity.y > 0)
        {
            box.isTrigger = true;
            circle.isTrigger = true;
        }

        if (Input.GetKeyDown(KeyCode.Space)&&this.rigid2D.velocity.y==0)
        {
            this.animator.SetBool("Jump", true);
            this.animator.SetBool("Walking", false);
            Jumping = true;
            box.isTrigger = true;
            circle.isTrigger = true;
            this.rigid2D.AddForce(transform.up * this.jump);

            GetComponent<AudioSource>().Play();
            

        }

        if (this.rigid2D.velocity.y <-3.0f)
        {

            box.isTrigger = false;
            circle.isTrigger = false;
            this.animator.SetBool("Jump", false);
            Jumping = false;
       
        }



        if (contral)
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                if (key == -1)
                    this.rigid2D.velocity = new Vector3(0, this.rigid2D.velocity.y, 0);
                key = 1;
                if (this.rigid2D.velocity.y == 0 && Jumping == false)
                    this.animator.SetBool("Walking", true);
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                if (key == 1)
                    this.rigid2D.velocity = new Vector3(0, this.rigid2D.velocity.y, 0);
                key = -1;
                if (this.rigid2D.velocity.y == 0 && Jumping == false)
                    this.animator.SetBool("Walking", true);
            }
            else
            {
                key = 0;
            }



            if (key == 0)
            {
                this.animator.SetBool("Walking", false);
            }

            float speedx = Mathf.Abs(this.rigid2D.velocity.x); //velocity 현재 객체 속도 , 속도는 부호가 있기에Abs => 절대값

            if (speedx < this.maxWalkSpeed)
            {
                this.rigid2D.AddForce(transform.right * key * this.walkForce);
            }
        }
        if(key != 0)
        {
            transform.localScale = new Vector3(key, 1, 1); // 스케일로 화면 반전
        }

        if(transform.position.x>2.6f) // 화면 양옆 이동하기 
        {
            transform.position = new Vector3(-2.3f, this.transform.position.y, 0);
        }
        if (transform.position.x <-2.6f) // 화면 양옆 이동하기 
        {
            transform.position = new Vector3(2.3f, this.transform.position.y, 0);
        }

        if (transform.position.y <beforeY-20.0f)
        {
            SceneManager.LoadScene("ClearScene");
        }
       
	}

    public void notContral()
    {
        contral = false;
    }

    public void contralable()
    {
        contral = true;
    }
    public bool GetContral()
    {
        return contral;

    }
 
    private void OnCollisionStay2D(Collision2D collision)
    {
        this.animator.SetBool("Jump", false);
      
        if(this.rigid2D.velocity.y==0&& collision.transform.position.y>beforeY)
        {
            evenScore.GetComponent<evenShow>().show((int)((collision.transform.position.y - beforeY) * 5));
            Director.GetComponent<GameDiretor>().AddScore((int)((collision.transform.position.y - beforeY) * 5));
            beforeY = collision.transform.position.y;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)//일반 점프시 collision 호출됨
    {



        if (collision.transform.position.y - beforeY > 0)
        {

            evenScore.GetComponent<evenShow>().show((int)((collision.transform.position.y - beforeY) * 5));
            Director.GetComponent<GameDiretor>().AddScore((int)((collision.transform.position.y - beforeY) * 5));
            beforeY = collision.transform.position.y;
        }
    
    }
    public float GetBeftoreCloude()
    {
        return beforeY;
    }

    private void OnTriggerEnter2D(Collider2D collision) // 스프링 구름을 통과하면서 밟았을때 Trigger로 호출 됨??
    {
        if (collision.gameObject.tag == "can")
        {
            if (can_ones)
            {
                Director.GetComponent<GameDiretor>().AddCan();
                Destroy(collision.gameObject);
                can_ones = false;
            }
            else
            {
                can_ones = true;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {


        float size = this.GetComponent<BoxCollider2D>().size.x;
        //구름옆에 닿는것 말고 재대로 착지 했을 때
        if (collision.transform.position.y < transform.position.y && collision.transform.position.x > this.transform.position.x - size / 2 &&
            collision.transform.position.x < this.transform.position.x + size / 2)
        {

            if (collision.transform.position.y - beforeY > 0)
            {

                box.isTrigger = false;
                circle.isTrigger = false;
                evenScore.GetComponent<evenShow>().show((int)((collision.transform.position.y - beforeY) * 50));
                Director.GetComponent<GameDiretor>().AddScore((int)((collision.transform.position.y - beforeY) * 50));
                beforeY = collision.transform.position.y;


            }
        }
    }

}
