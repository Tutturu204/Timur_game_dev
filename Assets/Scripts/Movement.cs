using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    public Animator anim;
    public Rigidbody2D rb;
    public Player_input_action playercontrol;
    
    //for attack circle
    public Transform attackPoint;

    public float moveSpeed = 1f;

    Vector2 moveDirection = Vector2.zero;

    private Vector2 m;
    public bool canMove = true;


    private void Awake()
    {
        playercontrol = new Player_input_action();
    }
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("Speed", Mathf.Abs(m.x) + Mathf.Abs(m.y));

    }


    private void FixedUpdate()
    {
        //variant 1
        //rb.MovePosition(rb.position + m * moveSpeed * Time.fixedDeltaTime);

        //variant 2
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Player_Attack"))
        {
            canMove = false;
            //Debug.Log("movement stoped!");
        }
        else
        {
            canMove = true;
        }

        //Here the movement happen! Change the velocity of the rigidbody
        //It should be within OnUpdate if we want to move by HOLDING keys
        if (canMove && (m.x != 0 || m.y != 0))
        {
            anim.SetFloat("X_axis", m.x);
            anim.SetFloat("Y_axis", m.y);
            rb.velocity = m * moveSpeed;
        }


        //variant3
        //rb.AddForce(m * moveSpeed);

    }


    public void OnMove(InputValue value)
    {
        
        m = value.Get<Vector2>();
        
        //Here where animation happend! Triggers when key pressed
        if (canMove && m != Vector2.zero)
        {
            
            if (m.x > 0)
            {
                attackPoint.transform.localPosition = new Vector2(1f, 0f);
            }
            else if (m.x < 0) 
            {
                attackPoint.transform.localPosition = new Vector2(-1f, 0f);
            }

            if (m.y > 0)
            {
                attackPoint.transform.localPosition = new Vector2(0f, 1f);
            }
            else if (m.y < 0)
            {
                attackPoint.transform.localPosition = new Vector2(0f, -1f);
            }

            
            
        }
        


    }

    public void OnFire() 
    {
        print("Shots");   
    }
    
}   

