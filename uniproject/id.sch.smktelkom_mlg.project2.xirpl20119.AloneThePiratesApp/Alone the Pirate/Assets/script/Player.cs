using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {


    public float maxSpeed = 3;
    public float Speed = 50f;
    public float jumpPower = 150f;

    public bool Grounded;

    public bool canDoubleJump;

    public int curHealth ;
    public int maxHealth = 100;

    private Rigidbody2D rb2d;
    private Animator anim;
    private gameMaster gm;
	void Start () {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();

        curHealth = maxHealth;
        gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<gameMaster>();

	}
 


    void Update () {

       

        anim.SetBool("Grounded",Grounded);
        anim.SetFloat("Speed", Mathf.Abs(rb2d.velocity.x));

        if(Input.GetAxis("Horizontal") < -0.1f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        if (Input.GetAxis("Horizontal") > 0.1f)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        if(Input.GetButtonDown("Jump"))
        {
            if (Grounded)
            {
                rb2d.AddForce(Vector2.up * jumpPower);
                canDoubleJump = true;
            }
            else
            {

                if(canDoubleJump)
                {
                    canDoubleJump = false;
                    rb2d.velocity = new Vector2(rb2d.velocity.x, 0);
                    rb2d.AddForce(Vector2.up * jumpPower / 1.5f);
                }

            }
        
        }
        if (curHealth > maxHealth)
        {
            curHealth = maxHealth;
        }

        if(curHealth <= 0)
        {
            Die();
        }
    }
    void FixedUpdate()
    {
        Vector3 easeVelocity = rb2d.velocity;
        easeVelocity.y = rb2d.velocity.y;
        easeVelocity.z = 0.0f;
        easeVelocity.x *= 0.75f;
        float h = Input.GetAxis("Horizontal");

        //take friction
        if(Grounded)
        {

            rb2d.velocity = easeVelocity;

        }


        //moving player
        rb2d.AddForce((Vector2.right * Speed )* h);

        //limitation speed
        if(rb2d.velocity.x > maxSpeed)
        {
            rb2d.velocity = new Vector2(maxSpeed, rb2d.velocity.y);
        }

        if(rb2d.velocity.x < -maxSpeed)
        {
            rb2d.velocity = new Vector2(-maxSpeed, rb2d.velocity.y);
        }
    }

    void Die()
    {
        //restart
        Application.LoadLevel(0);




    }

    public void Damage(int dmg)
    {
        curHealth -= dmg;
        gameObject.GetComponent<Animation>().Play("p_redflash");

    }

    public IEnumerator Knockback(float knockDur,float knockbackPwr,Vector3 knockbackDir)
    {
        float timer = 0;
        rb2d.velocity = new Vector2(rb2d.velocity.x, 0);
        while( knockDur > timer)
        {
            timer += Time.deltaTime;
            rb2d.AddForce(new Vector3(knockbackDir.x * 0, knockbackDir.y * -4, transform.position.z));
        }
        yield return 0;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Coin"))
        {
            Destroy(col.gameObject);
            gm.points += 1;
        }
        if (col.CompareTag("Health"))
            {
            Destroy(col.gameObject);
            curHealth = maxHealth;
            }
    }
    
 
   
}
