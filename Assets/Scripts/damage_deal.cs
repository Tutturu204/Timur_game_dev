using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damage_deal : MonoBehaviour
{
    private void Start()
    {
        Debug.Log("We are herer");
    }

    private void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.tag.Equals("Player") == true)
        {
            Debug.Log("Entering Collision");
            
            target.gameObject.GetComponent<Player>().TakeDamage(25);
        }

    }

    private void OnCollisionStay2D(Collision2D target)
    {
        if (target.gameObject.tag.Equals("Player") == true)
        {
            Debug.Log("Still in collision");
        }
        
    }
    
}
