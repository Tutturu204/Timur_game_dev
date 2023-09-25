using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private PlayerInput playerInput;
    public int maxHealth = 100;
    public int currentHealth;

    public health_bar healthBar;

    private void Awake()
    {

        playerInput = GetComponent<PlayerInput>();

    }
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInput.actions["Jump"].triggered)
        {
            Debug.Log("trigered");
            TakeDamage(20);
        }
    }

    void TakeDamage(int damage) 
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
}
