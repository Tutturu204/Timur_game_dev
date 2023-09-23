using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_chase : MonoBehaviour
{
    public float speed = 2f;
    private Rigidbody2D rb;
    public Transform target;
    Vector2 moveDirection;
    float angle;
    public float LineOfSight;
    
    // Start is called before the first frame update

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

    }
    void Start()
    {
        
    }


    // Update is called once per frame
    private void Update()
    {
        if (target)
        {
            Vector3 direction = (target.transform.position - transform.position).normalized;
            angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            moveDirection = direction;
        }
    }

    private void FixedUpdate()
    {
        float distance_to_player = Vector2.Distance(target.transform.position, this.transform.position);
        if (distance_to_player < LineOfSight)
        {
            rb.rotation = angle;
            rb.velocity = new Vector2(moveDirection.x, moveDirection.y) * speed;
        }
        else 
        {
            rb.rotation = angle;
            rb.velocity = new Vector2(0, 0) * speed;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(this.transform.position, LineOfSight);
    }

}
