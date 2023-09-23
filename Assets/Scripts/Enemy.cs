using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //public float speed = 2f;
    //private Rigidbody2D rb;
    //public Transform target;
    //Vector2 moveDirection;

    public Animator anim;
    public int maxhealth  = 100;
    private int currenthealth;
    // Start is called before the first frame update
    
    //private void Awake()
    //{
    //    rb = GetComponent<Rigidbody2D>();
        
    //}

    void Start()
    {
        currenthealth = maxhealth;
    }

    
    public void TakeDamage(int damage) {
        currenthealth -= damage;

        //play hurt animation
        anim.SetTrigger("Hurt");
        if (currenthealth <= 0) {
            Die();
        }
    }

    public void Die() {
        //cast die anim
        anim.SetBool("IsDead", true);

        //disable the script and component
        GetComponent<BoxCollider2D>().enabled = false;
        this.enabled = false;
        //Debug.Log("Enemy Died");
    }
}
