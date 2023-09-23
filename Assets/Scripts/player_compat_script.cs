using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class player_compat_script : MonoBehaviour
{
    private PlayerInput playerInput;
    public Animator anim;

    public Transform attackPoint;
    public float attackrange = 0.5f;
    public LayerMask enemyLayers;
    public float attackrate = 5f;
    float nextAttackTime = 0f;

    // Start is called before the first frame update
    private void Awake()
    {
        
       playerInput = GetComponent<PlayerInput>();
        
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextAttackTime) {
            if (playerInput.actions["Attack"].triggered)
            {
                
                Attack();
                nextAttackTime = Time.time + 1f / attackrate;
            }

        }


    }

    void Attack() {

        

        //Play an attack animation
        anim.SetTrigger("Attack");


        //Debug.Log("Attacking");

        //Detect all enemies that are in range of the attack
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackrange, enemyLayers);

        //Damage them!
        foreach (Collider2D enemy in hitEnemies) {
            //Debug.Log("Hit " + enemy.name);
            enemy.GetComponent<Enemy>().TakeDamage(25);
        }

        
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null) {
            return;

        }
        Gizmos.DrawWireSphere(attackPoint.position, attackrange);
    }
}
