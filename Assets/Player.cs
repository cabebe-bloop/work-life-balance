using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{   
    [SerializeField]float moveSpeed = 5f;
    public Rigidbody2D rb;
    Vector2 movement; 
    public Animator animator;

    // add max health
    public float currentHealth = 20f;
    public PhysHealthBar physHealthBar;

    void Update()
    {   
        // StartCoroutine(decreaseHealth());
        
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.magnitude);
    }
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    // IEnumerator decreaseHealth()
    // {
    //     while (currentHealth > 0)
    //     {
    //         currentHealth -= 0.5f;
    //         physHealthBar.SetHealth(currentHealth);
    //         yield return new WaitForSeconds(1);
    //     }
    // }

}
