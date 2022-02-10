using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.

public class Player : MonoBehaviour
{   
    [SerializeField]float moveSpeed = 5f;
    public Rigidbody2D rb;
    Vector2 movement; 
    public Animator animator;

    public float maxHealth = 50f;
    public float currentPhysHealth;
    public float currentEmoHealth;


    public HealthBar physHealthBar;

    public HealthBar emoHealthBar;

    public Interactions interaction;

    public bool recentAction = false;


    void Start() {
        // physHealthBar.SetMaxHealth(maxHealth);
        currentPhysHealth = maxHealth;
        currentEmoHealth = maxHealth;
        physHealthBar.SetMaxHealth(maxHealth);
        emoHealthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {   
        movement.x = (interaction.isNapping) ? 0 : Input.GetAxis("Horizontal");
        movement.y = (interaction.isNapping) ? 0: Input.GetAxis("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.magnitude);

        // StartCoroutine(DecreasePhysHealth());
        // StartCoroutine(DecreaseEmoHealth());
        DecreaseEmoHealth();

        if (interaction.plantBeingWatered && Input.GetKeyDown("space"))
        {    
            // seems to be running multiple times (maybe for the entire duration the condition is true?)
            // how can I say "only run this once"
            if (recentAction)
            {
                return;
            } else if (!recentAction)
            {
                recentAction = true;
                AddEmoHealth(5);
            }
        }

        if (interaction.isNapping && Input.GetKeyDown("space"))
        {
            if (recentAction)
            {
                return;
            } else if (!recentAction)
            {
                recentAction = true;
                AddPhysHealth(5);
                animator.SetBool("Asleep", true);
            }
            // return null; 
        }
    }
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    // Figure out the while loop condition and why it runs the coroutine so often
    // Find a solution (maybe check Unity order of execution?) to place DecreaseHealth in an area where the while loop actually
    // waits the 3 seconds.
    // IEnumerator DecreasePhysHealth()
    // {
    //     while (currentPhysHealth > 0)
    //     { 
    //         yield return new WaitForSeconds(3);
    //         currentPhysHealth -= 0.01f;
    //         physHealthBar.SetHealth(currentPhysHealth);
    //     }
    // }
    // IEnumerator DecreaseEmoHealth()
    // {
    //     // yield return new WaitForSeconds(1);
    //     while (currentEmoHealth > 0)
    //     { 
    //         yield return new WaitForSeconds(3);
    //         currentEmoHealth -= 0.01f;
    //         emoHealthBar.SetHealth(currentEmoHealth);
    //     }
    // }

    public void DecreaseEmoHealth ()
    {
        if (currentEmoHealth > 0) 
        {
            if (interaction.plantBeingWatered) {
                StartCoroutine(Wait(2));
            } else
            {
            StartCoroutine(Wait(1));
            currentEmoHealth -= 0.05f;
            emoHealthBar.SetHealth(currentEmoHealth);
            }
        } 
    }

// public void DecreasePhysHealth ()
// {
//     if (currentPhysHealth > 0)
//     {
//         if ()
//     }
// }

    IEnumerator Wait (float seconds) 
    {
        yield return new WaitForSeconds(seconds);
    }
    public void AddPhysHealth (float health) 
    {
        currentPhysHealth += health;
        physHealthBar.SetHealth(currentPhysHealth);
    }
    
    public void AddEmoHealth (float health) 
    {
        currentEmoHealth += health;
        emoHealthBar.SetHealth(currentEmoHealth);
    }

}
