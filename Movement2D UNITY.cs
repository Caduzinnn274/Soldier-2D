using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Soldado : MonoBehaviour
{

    public float speed;
    public float jumpForce;
    
    public bool podeAndar;
    private float movement;
    
    private Rigidbody2D rig;
    private Animator anim;
    
    // Start is called before the first frame update
  void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        
        podeAndar = false;
    }
    
    void Update()
    {
        Move();
        Jump();
        
    }
       void Move()
    {
        movement = Input.GetAxis("Horizontal");

        rig.velocity = new Vector2(movement * speed, rig.velocity.y);

        if(movement > 0 )
        {
            podeAndar = true;
            transform.eulerAngles = new Vector3(0, 0, 0);
            anim.SetBool("Walk", true);
      
        }

        if(movement < 0 )
        {
            podeAndar = true;
            transform.eulerAngles = new Vector3(0, 180, 0);
            anim.SetBool("Walk", true);
      

        }

        if(movement == 0)
        {
            anim.SetBool("Walk", false);
            podeAndar = false;
            
        }
    }
    void Jump()
    {
        if(Input.GetButtonDown("Jump"))
        {
            if(!isJumping)
            {
              rig.AddForce(new Vector2(0,jumpForce), ForceMode2D.Impulse);
                isJumping = true;
            }
            
        }

    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.layer == 8)
        {
            isJumping = false;


        }
   }
