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

    public Interactions interaction;

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

        StartCoroutine(DecreaseHealth());

        if (interaction.plantBeingWatered && Input.GetKeyDown("space"))
        {    
            // seems to be running multiple times (maybe for the entire duration the condition is true?)
            // how can I say "only run this once"
            AddPhysHealth(3);
        }

        if (interaction.isNapping && Input.GetKeyDown("space"))
        {
            AddPhysHealth(5);
        }
    }
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    // Figure out the while loop condition and why it runs the coroutine so often
    // Find a solution (maybe check Unity order of execution?) to place DecreaseHealth in an area where the while loop actually
    // waits the 3 seconds.
    IEnumerator DecreaseHealth()
    {
        yield return new WaitForSeconds(1);
        while (currentHealth > 0)
        { 
            if (interaction.plantBeingWatered) 
            {
                yield return null;
            }
            // Debug.Log("START:" + Time.time);
            yield return new WaitForSeconds(3);
            currentHealth -= 0.01f;
            physHealthBar.SetHealth(currentHealth);
            // Debug.Log("STOP:" + Time.time);
        }
    }

    public void AddPhysHealth (float health) 
    {
        currentHealth += health;
        physHealthBar.SetHealth(currentHealth);
    }

}
