using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{   
    [SerializeField]float moveSpeed = 5f;
    public Rigidbody2D rb;
    Vector2 movement; 
    public Animator animator;

    public float maxHealth = 50f;
    public float currentHealth;
    public PhysHealthBar physHealthBar;

    void Start() {
        currentHealth = maxHealth;
        physHealthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {   
        
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.magnitude);
    }
    void FixedUpdate()
    {
        StartCoroutine(DecreaseHealth());
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    IEnumerator DecreaseHealth()
    {
        while (currentHealth > 0)
        {
            Debug.Log("START:" + Time.time);
            currentHealth -= 0.005f;
            physHealthBar.SetHealth(currentHealth);
            yield return new WaitForSeconds(5);
            Debug.Log("STOP:" + Time.time);
        }
    }

}
