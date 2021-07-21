using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Speed;
    public float JumpForce;
    private Rigidbody2D rig;
    private Animator anim;

    public bool IsJumping;
    public bool doubleJump;
    bool isBlowing ;


    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
    }

    void Move()
    {
        //Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        //transform.position += movement * Time.deltaTime * Speed;
        float movement = Input.GetAxis("Horizontal");
        rig.velocity = new Vector2(movement * Speed, rig.velocity.y);
        if(movement > 0f)
        {
        anim.SetBool("Walk", true);
        transform.eulerAngles = new Vector3(0f,0f,0f);
        }
        if(movement< 0f)
        {
        anim.SetBool("Walk", true);
        transform.eulerAngles = new Vector3(0f,180f,0f);
        }
        if(movement == 0f)
        {
        anim.SetBool("Walk", false);
        }
    }

    void Jump()
    {
            if (Input.GetButtonDown("Jump") && !isBlowing)
            {
                if(!IsJumping)
                {
                    rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
                    doubleJump = true;
                    anim.SetBool("Jump", true);
                }
                else
                {
                    if(doubleJump)
                    {
                         rig.AddForce(new Vector2(0f, JumpForce * 2f), ForceMode2D.Impulse);
                         doubleJump = false;
                    }
                }
                
            }  
    }

    void OnCollisionEnter2D(Collision2D collision) 
    {
        if(collision.gameObject.layer == 8)
        {
            IsJumping = false;
            anim.SetBool("Jump", false);
        }
        if(collision.gameObject.tag == "Death")
        {
            GameController.instance.ShowGameOver();
            Destroy(gameObject);
        }
    }

     void OnCollisionExit2D(Collision2D collision) 
    {
        if(collision.gameObject.layer == 8)
        {
            IsJumping = true;
        }
    }

    void OnTriggerStay2D(Collider2D collider) 
    {
        if(collider.gameObject.layer == 11)
        {
            isBlowing = true;
        }
    }

    void OnTriggerExit2D(Collider2D collider) 
    {
        if(collider.gameObject.layer == 11)
        {
            isBlowing = false;
        }
    }

}
