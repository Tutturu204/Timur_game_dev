using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public InputAction inputaction;
    public float speed = 1f;
    private Rigidbody2D charbody;
    private Vector2 velocity;
    private Vector2 moveinput;
    public Animator anim;
    
    public InputAction playercontrol;

    //[SerializeField]
    //private InputActionReference movement, shoot, pointerPosition;


    private void OnEnable()
    {
        playercontrol.Enable();
    }

    private void OnDisable()
    {
        playercontrol.Disable();
    }
    // Start is called before the first frame update
    void Start()
    {
        //speed for x and y directions. That is why we use Vector2
        velocity = new Vector2(speed, speed);

        //take the object from the gameObject
        charbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    /*
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        inputMove = new Vector2
        (
            horizontal,
            vertical

        );

        /*
        if (horizontal > 0.1f) 
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 90f);
        }
        
        //tell me what animation to play
        anim.SetFloat("Speed", Mathf.Abs(horizontal) + Mathf.Abs(vertical));

    }
    */
    private void FixedUpdate()
    {
        //change in the 2D space
        //Vector2 delta = moveinput * speed * Time.deltaTime;
        //Vector2 newPosition = charbody.position + delta;
        //charbody.MovePosition(newPosition);
        //moveinput = movement.action.ReadValue<Vector2>();
        charbody.MovePosition(charbody.position + moveinput * speed * Time.deltaTime);


    }

    public void OnMove(InputValue value)
    {

        //moveinput = value.Get<Vector2>();
        moveinput = playercontrol.ReadValue<Vector2>();
        anim.SetFloat("X_axis", moveinput.x);
        anim.SetFloat("Y_axis", moveinput.y);

    }
    
}
